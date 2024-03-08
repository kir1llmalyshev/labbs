namespace labb3.DB;

public interface IRepo
{
    void SaveToDb(IEnumerable<ContactDto> contacts);
    List<ContactDto> LoadFromDb();
    void SaveToJson(List<ContactDto> contacts);
    List<ContactDto> LoadFromJson();
}