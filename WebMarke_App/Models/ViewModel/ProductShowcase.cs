using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;

namespace WebMarke_App.Models.ViewModel
{
    public class ProductShowcase
    {
        public Product? Product { get; set; }

        [ValidateNever]
        public List<Product> ProductList { get; set; } = [];

        [ValidateNever]
        public IEnumerable<SelectListItem>? CategoryList { get; set; }

        [ValidateNever]
        public List<Category> Categoryy { get; set; } = [];
    }

    //public class FibSeries : IEnumerable<ulong>
    //{
    //    public IEnumerator<ulong> GetEnumerator()
    //    {
    //        return new FibCalculator();
    //    }

    //    IEnumerator IEnumerable.GetEnumerator()
    //    {
    //        return new FibCalculator();   
    //    }
    //}

    //public class FibCalculator : IEnumerator<ulong>
    //{
    //    private ulong a = 1;
    //    private ulong b = 1;

    //    public ulong Current => a;
    //    object IEnumerator.Current => a;

    //    public void Dispose()
    //    {
    //    }

    //    public bool MoveNext()
    //    {
    //        var temp = a + b;

    //        a = b;
    //        b = temp;

    //        return true;
    //    }

    //    public void Reset()
    //    {
    //        a = 1; b = 1;
    //    }
    //}
}
