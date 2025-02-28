using AutoMapper;
using Bookly.APIs.DTOs;
using Bookly.APIs.Entities;
using Bookly.APIs.Interfaces;
using Bookly.APIs.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bookly.APIs.Controllers
{

    public class BooksController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BooksController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<BookDto>>> GetBooks()
        {
            var spec = new BookWithAuthorsSpecifications();
            var books = await _unitOfWork.Repository<Book>().GetAllWithSpecAsync(spec);
            return Ok(_mapper.Map<IReadOnlyList<Book>, IReadOnlyList<BookDto>>(books));
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetBook(int id)
        {
            var spec = new BookWithAuthorsSpecifications(id);
            var book = await _unitOfWork.Repository<Book>().GetEntityWithSpecAsync(spec);
            if (book is null) return NotFound();
            return Ok(_mapper.Map<Book, BookDto>(book));
        }


        [HttpPost]
        public async Task<ActionResult<BookDto>> AddBook(BookDto bookDto)
        {
            var mappedBook = _mapper.Map<BookDto, Book>(bookDto);
            await _unitOfWork.Repository<Book>().AddAsync(mappedBook);
            await _unitOfWork.Complete();
            return Ok(bookDto);
        }

        [HttpPut]
        public async Task<ActionResult<BookDto>> UpdateBook(BookDto bookDto)
        {
            var mappedBook = _mapper.Map<BookDto, Book>(bookDto);
             _unitOfWork.Repository<Book>().Update(mappedBook);
            await _unitOfWork.Complete();
            return Ok(bookDto);
        }

    }
}
