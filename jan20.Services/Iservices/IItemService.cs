using jan20.Model;

namespace jan20.Services.Iservices
{
    public interface IItemService
    {

        List<Item> GetItems(int shopId);
        Item GetItem(int id);
        int UpdateItem(Item obj);
        int DeleteItem(int Id);
        int AddItem(Item item);

        bool isPublished(int itemId, bool ispublished);
        bool ShowInHomePage(int itemId, bool hideShow);

    }
}
