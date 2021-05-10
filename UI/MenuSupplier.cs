using UI.Menus;

namespace UI

{
    /// <summary>
    /// When called this class will provide the user with a menu of a certian type
    /// </summary>
    public class MenuSupplier
    {
        public static IMenu CreateMenu(string menuType)
        {
            switch(menuType.ToLower())
            {
                case "customer":
                    return new CustMainMenu();
                case "login":
                    return new LoginMenu();
                case "manager":
                    return new ManagerMainMenu();
                default: 
                    return null;
            }
        }
    }
}