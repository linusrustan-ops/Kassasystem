using Kassasystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kassasystem.Repos
{
    public interface IProductRepo
    {
        Product? GetProductByID(int id);
        bool CheckIfNameExists(string name);
        int GenerateID();
        bool AddToDictionary(Product product);
        void ExportDictionary();
    }
}
