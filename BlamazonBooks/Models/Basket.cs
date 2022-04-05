﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlamazonBooks.Models
{
    public class Basket
    {
        // Declare and initialize 
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();
        
        public virtual void AddItem(Book bk, int qty)
        {
            BasketLineItem line = Items
                .Where(b => b.Book.BookId == bk.BookId)
                .FirstOrDefault();
            if (line == null)
            {
                Items.Add(new BasketLineItem
                {
                    Book = bk,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }

        public virtual void RemoveItem(Book book)
        {
            Items.RemoveAll(x => x.Book.BookId == book.BookId);
        }

        public virtual void ClearAll()
        {
            Items.Clear();
        }
        public virtual double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Quantity * x.Book.Price); 
            return sum;
        }
    }
    public class BasketLineItem
    {
        public int LineID { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}
