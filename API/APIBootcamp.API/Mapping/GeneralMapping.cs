﻿using APIBootcamp.API.DTOs.CategoryDTOs;
using APIBootcamp.API.DTOs.ContactDTOs;
using APIBootcamp.API.DTOs.FeatureDTOs;
using APIBootcamp.API.DTOs.MessageDTOs;
using APIBootcamp.API.DTOs.NotificationDTOs;
using APIBootcamp.API.DTOs.ProductDTOs;
using APIBootcamp.API.Entities.Concrete;
using AutoMapper;

namespace APIBootcamp.API.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Feature, ResultFeatureDTO>().ReverseMap();
            CreateMap<Feature, CreateFeatureDTO>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDTO>().ReverseMap();
            CreateMap<Feature, GetByIdFeatureDTO>().ReverseMap();

            CreateMap<Message, ResultMessageDTO>().ReverseMap();
            CreateMap<Message, CreateMessageDTO>().ReverseMap();
            CreateMap<Message, UpdateMessageDTO>().ReverseMap();
            CreateMap<Message, GetByIdMessageDTO>().ReverseMap();

            CreateMap<Notification, ResultNotificationDTO>().ReverseMap();
            CreateMap<Notification, CreateNotificationDTO>().ReverseMap();
            CreateMap<Notification, UpdateNotificationDTO>().ReverseMap();
            CreateMap<Notification, GetByIdNotificationDTO>().ReverseMap();

            CreateMap<Contact, ResultContactDTO>().ReverseMap();
            CreateMap<Contact, CreateContactDTO>().ReverseMap();
            CreateMap<Contact, UpdateContactDTO>().ReverseMap();
            CreateMap<Contact, GetByIdContactDTO>().ReverseMap();

            CreateMap<Product, ResultProductWithCategoryDTO>().ForMember(x => x.CategoryName, y => y.MapFrom(z => z.Category.CategoryName)).ReverseMap();
            CreateMap<Product, CreateProductDTO>().ReverseMap();
            CreateMap<Product, UpdateProductDTO>().ReverseMap();
            CreateMap<Product, ResultProductDTO>().ReverseMap();
            CreateMap<Product, GetByIdProductDTO>().ReverseMap();

            CreateMap<Category, ResultCategoryDTO>().ReverseMap();
            CreateMap<Category, CreateCategoryDTO>().ReverseMap();
            CreateMap<Category, UpdateCategoryDTO>().ReverseMap();
            CreateMap<Category, GetByIdCategoryDTO>().ReverseMap();

        }
    }
}
