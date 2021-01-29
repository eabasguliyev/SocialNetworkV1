using System;
namespace SocialNetworkV1
{
    class Program
    {
        static void Main(string[] args)
        {
            var mainMenuLoop = true;
            while (mainMenuLoop)
            {
                SocialNetwork.PrintMenu(SocialNetwork.MainMenuOptions);

                switch (SocialNetwork.InputChoice(SocialNetwork.MainMenuOptions.Length))
                {
                    case 1:
                    {
                        var adminMenuLoop = true;
                        while (adminMenuLoop)
                        {
                            SocialNetwork.PrintMenu(SocialNetwork.AdminMenuOptions);

                            switch (SocialNetwork.InputChoice(SocialNetwork.AdminMenuOptions.Length))
                            {
                                case 8:
                                {
                                    adminMenuLoop = false;
                                    break;
                                }
                                default:
                                    break;
                            }
                        }
                        break;
                    }
                    case 2:
                    {
                        var userMenuLoop = true;
                        while (userMenuLoop)
                        {
                            SocialNetwork.PrintMenu(SocialNetwork.UserMenuOptions);

                            switch (SocialNetwork.InputChoice(SocialNetwork.UserMenuOptions.Length))
                            {
                                case 5:
                                {
                                    userMenuLoop = false;
                                    break;
                                }
                                default:
                                    break;
                            }
                        }
                        break;
                    }
                    case 3:
                    {
                        mainMenuLoop = false;
                        break;
                    }
                    default:
                        break;
                }
            }
        }
    }
}
