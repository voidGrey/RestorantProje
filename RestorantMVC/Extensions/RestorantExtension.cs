using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Entites.Concrate;
using Entites.Abstract;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace RestorantMVC.Extensions
{
    public static class RestorantExtension
    {
        public static IQueryable<TModel> FirmaFilter<TModel>(this DbSet<TModel> model , string id) where TModel : BaseEntity
        {
            return model.Where(a => a.FirmaId == id);
        }


    }
}
