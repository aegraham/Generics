// --------------------------------------------------------------------------------------------------------------------
// <copyright company="twentysix" file="DiscountCalculator.cs">
// Copyright (c) twentysix.  All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Generics
{
    public class DiscountCalculator<TProduct> where TProduct : Product
    {
        public float CalulateDiscount(TProduct product)
        {
            return product.Price;
        }
    }
}