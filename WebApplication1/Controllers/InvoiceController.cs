using AutoMapper;
using BlazorApp.Data.Models;
using BlazorApp.Data.Repository;
using BlazorApp.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApplication1.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IInvoiceItemRepository _invoiceItemRepository;
        private readonly IMapper _mapper;

        public InvoiceController(IInvoiceRepository invoiceRepository, IInvoiceItemRepository invoiceItemRepository,
            IMapper mapper)
        {
            _invoiceRepository = invoiceRepository;
            _invoiceItemRepository = invoiceItemRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInvoice(int id)
        {
            return Ok(_mapper.Map<InvoiceModel>(await _invoiceRepository.GetInvoice(x => x.Id == id)));
        }

        [HttpGet("invoice-items/{id}")]
        public async Task<IActionResult> GetInvoiceItems(int id)
        {
            return Ok(_mapper.Map<List<InvoiceItemModel>>(await _invoiceItemRepository.GetInvoiceItems(x => x.InvoiceId == id)));
        }

        [HttpPost]
        public async Task<IActionResult> Create(InvoiceCreateModel invoice)
        {
            if (ModelState.IsValid)
            {
                Invoice createInvoice = _mapper.Map<Invoice>(invoice.Invoice);
                await _invoiceRepository.Create(createInvoice);

                if (createInvoice.Id > 0)
                {
                    foreach (var item in invoice.InvoiceItems)
                    {
                        item.InvoiceId = createInvoice.Id;
                    }

                    List<InvoiceItem> items = _mapper.Map<List<InvoiceItem>>(invoice.InvoiceItems);

                    await _invoiceItemRepository.Create(items);

                    return Ok(createInvoice.Id);
                }

                return Problem("Something went wrong while saving Invoice.");
            }
            else
            {
                return BadRequest(ModelState);
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetInvoices()
        {
            return Ok(_mapper.Map<List<InvoiceModel>>(await _invoiceRepository.GetInvoices()));
        }

        //[HttpPut]
        //public async Task<IActionResult> Update(CategoryModel category)
        //{
        //    Category dbcategory = await _categoryRepository.Getcategory(x => x.Id == category.Id);

        //    if (dbcategory != null)
        //    {
        //        dbcategory.Name = category.Name;
        //        dbcategory.Description = category.Description;

        //        return Ok(await _categoryRepository.Update(dbcategory));
        //    }

        //    return NotFound("Category not found");
        //}
    }
}
