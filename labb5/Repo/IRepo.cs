using System.Collections.Generic;
using System.Collections.ObjectModel;
using labb5.Models;

namespace labb5.Repo;

public interface IRepo
{
    void SaveToDb(IEnumerable<ContactDto> contacts);
    List<ContactDto> LoadFromDb();
}