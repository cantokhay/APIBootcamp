﻿using APIBootcamp.API.Entities.Abstract;
using APIBootcamp.API.Entities.Enum;   

namespace APIBootcamp.API.Entities.Concrete
{
    public class Product : IGenericEntity<Product>
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription{ get; set; }
        public decimal ProductPrice{ get; set; }
        public string ProductImageURL{ get; set; }
        public DataStatus DataStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }

        public int? CategoryId { get; set; }
        public Category Category { get; set; }
    }
}

