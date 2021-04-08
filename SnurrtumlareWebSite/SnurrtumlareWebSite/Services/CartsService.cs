﻿using Microsoft.AspNetCore.Http;
using SnurrtumlareWebSite.Data;
using SnurrtumlareWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnurrtumlareWebSite.Services
{
    public class CartsService
    {
        public SnurrtumlareDbContext DbContext { get; set; }

        public CartsService()
        {
            DbContext = new SnurrtumlareDbContext();
        }

        public Cart GetCart(Cart cart)
        {
            if (cart == null)
            {
                cart = new Cart();
            }

            cart.CartTotalCost = 0;

            foreach (var item in cart.ProductsInCart)
            {
                cart.CartTotalCost += item.ProductPrice * item.Quantity;
            }

            return cart;
        }

        public Cart AddItemToCart(Cart cart, int productId)
        {
            if (cart == null)
            {
                cart = new Cart();
            }
            foreach (var item in cart.ProductsInCart)
            {
                if (item.ProductId == productId)
                {
                    item.Quantity++;

                    return cart;
                }
            }

            cart.ProductsInCart.Add(DbContext.Products.Single<Product>(p => p.ProductId == productId));
            cart.ContainsItems = true;

            return cart;
        }

        public Cart UpdateQuantity(Cart cart, int productId, int quantity)
        {
            foreach (var item in cart.ProductsInCart)
            {
                if (item.ProductId == productId)
                {
                    item.Quantity = quantity;

                    if (item.Quantity <= 0)
                    {
                        DeleteItemFromCart(cart, productId);

                        if (cart.ProductsInCart.Count == 0)
                        {
                            cart.ContainsItems = false;

                            return cart;
                        }
                    }
                }
            }

            return cart;
        }

        public Cart DeleteItemFromCart(Cart cart, int productId)
        {
            cart.ProductsInCart.Remove(cart.ProductsInCart.Single<Product>(p => p.ProductId == productId));

            if (cart.ProductsInCart.Count == 0)
            {
                cart.ContainsItems = false;
            }

            return cart;
        }

        public Cart ClearCart(Cart cart)
        {
            cart.ProductsInCart.Clear();

            cart.ContainsItems = false;

            return cart;
        }
    }

    
}
