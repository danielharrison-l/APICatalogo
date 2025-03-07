﻿using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;


namespace APICatalogo.Controllers;

    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
        var products = await _context.Products?.AsNoTracking().ToListAsync();
        if (products == null || !products.Any())
        {
            return NotFound("Produtos não encontrados");
        }

        return products;
        }

    [HttpGet("{id:int:min(1)}", Name="GetProduct")]

    public async Task<ActionResult<Product>> Get(int id)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
        if (product is null)
        {
            return NotFound("Produto não encontrado");
        }

        return product;

    }

    [HttpPost]
    public ActionResult Post(Product product)
    {
        if(product is null)
        {
            return BadRequest("Produto é nulo");
        }

        _context.Products.Add(product);
        _context.SaveChanges();

        return new CreatedAtRouteResult("GetProduct", new { id = product.ProductId }, product);
    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, Product product)
    {
        if (id != product.ProductId)
        {
            return BadRequest("Produto não encontrado");
        }

        _context.Entry(product).State = EntityState.Modified;
        _context.SaveChanges();

        return Ok(product);
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var product = _context.Products.FirstOrDefault(p => p.ProductId == id);
        
        if (product is null)
        {
            return NotFound("Produto não localizado...");
        }
        _context.Products.Remove(product);
        _context.SaveChanges();

        return Ok(product);
    }
    }
