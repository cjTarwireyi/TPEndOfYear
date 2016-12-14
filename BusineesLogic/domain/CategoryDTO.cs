using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CategoryDTO
/// </summary>
public class CategoryDTO
{
    public CategoryDTO(CategoryBuilder builder)
    {
        this.id = builder.id;
        this.name = builder.name;
        this.description = builder.description;
        this.dateCreated = builder.dateCreated;
    }
    public int id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public DateTime dateCreated { get; set; }

    public class CategoryBuilder
    {
        public int id;
        public string name;
        public string description;
        public DateTime dateCreated;
        public CategoryBuilder buildId(int id){
            this.id = id;
            return this;
        }
        public CategoryBuilder buildBrandName(string name)
        {
            this.name = name;
            return this;
        }
        public CategoryBuilder buildDescription(string desc)
        {
            this.description = desc;
            return this;
        }
        public CategoryBuilder buildDateCreated(DateTime date)
        {
            this.dateCreated = date;
            return this;
        }
        public CategoryBuilder copy(CategoryDTO category)
        {
            this.id = category.id;
            this.name = category.name;
            this.description = category.description;
            this.dateCreated = category.dateCreated;
            return this;
        }
        public CategoryDTO build()
        {
            return new CategoryDTO(this);
        }
    }

}