using System.Diagnostics.Eventing.Reader;
using System.Formats.Asn1;
using System.Numerics;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Text.Json;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Evos_Bot
{
    internal class Program
    {
        public static string UserInfoPath = @"D:\temp\EvosBot.txt";
        public static List<UserInfo> userInfos = new List<UserInfo>();
        public static UserInfo user = new UserInfo();
        static void Main(string[] args)
        {
            var token = "Your Token";
            var bot = new TelegramBotClient(token);
            bot.OnMessage += async (message, Type) =>
            {
                var chatId = message.Chat.Id;
                var message1 = message.From.Username;
                Console.WriteLine(message.Text);

                if (message.Text == "/start")
                {

                    await bot.SendMessage(chatId, "Assalomu alaykum, @" + message1 + "!\n" + """
🟢EVOS'ning rasmiy hamkor kanallariga a'zo bo'lishingiz orqali 🔖(50% chegirma) ni qo'lga kiriting.

(⚠️Hamkor kanallarimizga obuna bo'lmasdan botdan foydalana olmaysiz.)
""");

                    InlineKeyboardMarkup keyboard = new(new[]
                    {
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("Kanal 1","Kanal_1"),
                            InlineKeyboardButton.WithCallbackData("Kanal 2","Kanal2"),
                        }
                    });

                    CallbackQuery callbackQuery = new CallbackQuery();
                    HandCallBack(bot, callbackQuery);
                    await bot.SendMessage(chatId, "Choose one of them", replyMarkup: keyboard);
                    CallbackQuery callback = new CallbackQuery();
                    HandCallBack(bot, callback);
                    bot.SendMessage(chatId, """
                        EVOS | Доставка botiga xush kelibsiz!
                        Avval telefon raqamingizni yuboring,
                        yoki +998XX XXXXXXX ko'rinishida yozing.
                        
                        """);
                    await bot.SendMessage(chatId, "Biz kutmoqdamiz!", replyMarkup: GetButtons());

                }
                else if (message.Contact != null)
                {
                    bot.SendMessage(chatId, "Telefon raqamingiz qabul qilindi✅");
                    //user.UserName = message1.ToString();
                    //user.Contact = message.Contact.ToString();
                    //userInfos.Add(user);
                    //Writer(userInfos , UserInfoPath);
                    //JsonWriter(userInfos);
                    bot.SendMessage(chatId, "🛒 Asosiy Menyu");

                    await bot.SendMessage(chatId, "Marhamat buyurtma berishingiz mumkin!", replyMarkup: GetButtonsMenu());

                }
                else if (message.Text == "🍴Menu")
                {
                    bot.SendMessage(chatId, "Tanlang:", replyMarkup: GetFoodOnMenu());
                }
                else if(message.Text == "🔙Orqaga Qaytish (Menu)")
                {
                    bot.SendMessage(chatId, "🛒 Asosiy Menyu");
                    await bot.SendMessage(chatId, "Marhamat buyurtma berishingiz mumkin!", replyMarkup: GetButtonsMenu());
                }
                else if (message.Text == "Setlar")
                {
                    bot.SendPhoto(chatId, "https://ibb.co/tq2Lm1g", replyMarkup: Setlar());
                }
                else if (message.Text == "🔙Orqaga Qaytish")
                {
                    bot.SendMessage(chatId, "Tanlang:", replyMarkup: GetFoodOnMenu());
                }
                else if (message.Text == "Lavash")
                {
                    bot.SendPhoto(chatId, "https://ibb.co/dk666RL", replyMarkup: Lavashlar());
                }

                else if (message.Text == "Shaurma")
                {
                    bot.SendPhoto(chatId, "https://ibb.co/K616TWF", replyMarkup: Shaurmalar());
                }

                else if (message.Text == "Burger")
                {
                    bot.SendPhoto(chatId, "https://ibb.co/vmCdCD3", replyMarkup: Burgerlar());
                }

                else if (message.Text == "Hot-Dog")
                {
                    bot.SendPhoto(chatId, "https://ibb.co/7XDj1LH", replyMarkup: HotDoglar());
                }

                else if (message.Text == "Ichimliklar")
                {
                    bot.SendPhoto(chatId, "https://ibb.co/vHPDkT9", replyMarkup: Suv());
                }

                else if (message.Text == "Shirinlik va Desertlar")
                {
                    bot.SendPhoto(chatId, "https://ibb.co/QQHn2Fr", replyMarkup: Shirinlik());
                }

                else if (message.Text == "Garnirlar")
                {
                    bot.SendPhoto(chatId, "https://ibb.co/12nszJc", replyMarkup: Snack());
                }

                else if (message.Text == "Combo Plus Isituvchan (Qora choy)")
                {
                    InlineKeyboardMarkup QoraChoy = new(new[]
                    {
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("-","-"),InlineKeyboardButton.WithCallbackData("1","1"),InlineKeyboardButton.WithCallbackData("+","+"),
                        },
                         new[]{
                             InlineKeyboardButton.WithCallbackData("📥 Savatga qo'shish","savatQoraChoy")
                         }
                    });
                    bot.SendPhoto(chatId, "https://ibb.co/LkW8LnW", "Narxi: 16 000 som", replyMarkup: QoraChoy);
                }
                else if (message.Text == "FitCombo")
                {
                    InlineKeyboardMarkup FitCombo = new(new[]
                    {
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("-","-"),InlineKeyboardButton.WithCallbackData("1","1"),InlineKeyboardButton.WithCallbackData("+","+"),
                        },
                         new[]{
                             InlineKeyboardButton.WithCallbackData("📥 Savatga qo'shish","savatFit")
                         }
                    });
                    bot.SendPhoto(chatId, "https://ibb.co/Q8PsfR2", "Narxi: 30 000 som", replyMarkup: FitCombo);
                }
                else if (message.Text == "Iftar kofte grill mol go'shtidan")
                {
                    InlineKeyboardMarkup Grill = new(new[]
                    {
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("-","-"),InlineKeyboardButton.WithCallbackData("1","1"),InlineKeyboardButton.WithCallbackData("+","+"),
                        },
                         new[]{
                             InlineKeyboardButton.WithCallbackData("📥 Savatga qo'shish","savatKofte")
                         }
                    });

                    bot.SendPhoto(chatId, "https://ibb.co/Xk2prk5", "Muborak RAMAZON oyi munosabati bilan maxsus taklif! Mol go'shtli 5 dona shirali gril-kotletlari, guruch, limon sharbati bilan boyitilgan qizil karamli salat, pomidorlar va yong'oqlardan tayyorlangan maxsus quyuq RAMAZON sousi. Iftorlik vaqtingiz uchun ideal yechim!\nNarxi: 35 000 som", replyMarkup: Grill);
                }
                else if (message.Text == "Donar boxs mol go'shtidan")
                {
                    InlineKeyboardMarkup FitCombo = new(new[]
                    {
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("-","-"),InlineKeyboardButton.WithCallbackData("1","1"),InlineKeyboardButton.WithCallbackData("+","+"),
                        },
                         new[]{
                             InlineKeyboardButton.WithCallbackData("📥 Savatga qo'shish","savatDonerBox")
                         }
                    });

                    bot.SendPhoto(chatId, "https://ibb.co/1RV4J16", "YANGILIK! Oq kunjut sousi ostidagi shirali grill tovuq go'shti, qarsildoq kartoshka-fri, donador guruch, qizil karamdan tayyorlangan barra salatdan tashkil topgan qatlamlarning to'yimli uyg'unlashuvi. Qulay, ixcham, ammo to'yimli qadoq!\nNarxi: 34 000 som", replyMarkup: FitCombo);
                }
                else if (message.Text == "Donar boks tovuq go'shtidan")
                {
                    InlineKeyboardMarkup FitCombo = new(new[]
                    {
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("-","-"),InlineKeyboardButton.WithCallbackData("1","1"),InlineKeyboardButton.WithCallbackData("+","+"),
                        },
                         new[]{
                             InlineKeyboardButton.WithCallbackData("📥 Savatga qo'shish","savatDonerBox")
                         }

                    });

                    bot.SendPhoto(chatId, "https://ibb.co/pyWQww3", "YANGILIK!  Yangi, maxsus tayyorlangan teriyaki sousi, grill tovuq go'shti, qarsildoq kartoshka-fri, donador guruch, limon sharbati bilan to'yintirilgan qizil karamdan tayyorlangan barra salatning noodatiy mazali uyg'unlashuvi. Qulay, ixcham, ammo to'yimli qadoq!\nNarxi: 32 000 som", replyMarkup: FitCombo);
                }
                else if (message.Text == "COMBO+")
                {
                    InlineKeyboardMarkup FitCombo = new(new[]
                    {
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("-","-"),InlineKeyboardButton.WithCallbackData("1","1"),InlineKeyboardButton.WithCallbackData("+","+"),
                        },
                         new[]{
                             InlineKeyboardButton.WithCallbackData("📥 Savatga qo'shish","savatDonerBox")
                         }
                    });

                    bot.SendPhoto(chatId, "https://ibb.co/3hQyMpW", "Yeng yaxshi taklif! Issiq qarsildoq qovurilgan kartoshka va bir stakan Pepsi\nNarxi: 16 000 som", replyMarkup: FitCombo);
                }
                else if (message.Text == "Iftar strips tovuq go'shtidan")
                {
                    InlineKeyboardMarkup FitCombo = new(new[]
                    {
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("-","-"),InlineKeyboardButton.WithCallbackData("1","1"),InlineKeyboardButton.WithCallbackData("+","+"),
                        },
                         new[]{
                             InlineKeyboardButton.WithCallbackData("📥 Savatga qo'shish","savatStripsIftar")
                         }
                    });

                    bot.SendPhoto(chatId, "https://ibb.co/Xk2prk5", "Muborak RAMAZON oyi munosabati bilan maxsus taklif! Tovuqli 5 dona shirali gril-kotletlari, guruch, limon sharbati bilan boyitilgan qizil karamli salat, pomidorlar va yong'oqlardan tayyorlangan maxsus quyuq RAMAZON sousi. Iftorlik vaqtingiz uchun ideal yechim!\nNarxi: 30 000 som", replyMarkup: FitCombo);
                }
                else if (message.Text == "Kids COMBO")
                {
                    InlineKeyboardMarkup FitCombo = new(new[]
                    {
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("-","-"),InlineKeyboardButton.WithCallbackData("1","1"),InlineKeyboardButton.WithCallbackData("+","+"),
                        },
                         new[]{
                             InlineKeyboardButton.WithCallbackData("📥 Savatga qo'shish","savatKidsCombo")
                         }
                    });
                    bot.SendPhoto(chatId, "https://ibb.co/jvJGjJm", "Narxi: 16 000 som", replyMarkup: FitCombo);
                }
                else if (message.Text == "Mol go'shtidan qalampir lavash")
                {
                    InlineKeyboardMarkup FitCombo = new(new[]
                    {
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("-","-"),InlineKeyboardButton.WithCallbackData("1","1"),InlineKeyboardButton.WithCallbackData("+","+"),
                        },
                         new[]{
                             InlineKeyboardButton.WithCallbackData("📥 Savatga qo'shish","savatLavashMolQalampir")
                         }
                    });
                    bot.SendPhoto(chatId, "https://ibb.co/N97MhBF", "Narxi: 26 000 som", replyMarkup: FitCombo);
                }
                else if (message.Text == "Tovuq go'shtli qalampir lavash")
                {
                    InlineKeyboardMarkup FitCombo = new(new[]
                    {
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("-","-"),InlineKeyboardButton.WithCallbackData("1","1"),InlineKeyboardButton.WithCallbackData("+","+"),
                        },
                         new[]{
                             InlineKeyboardButton.WithCallbackData("📥 Savatga qo'shish","savatLavashTovuqQalampir")
                         }
                    });
                    bot.SendPhoto(chatId, "https://ibb.co/J2P1Z7f", "Narxi: 24 000 som", replyMarkup: FitCombo);
                }
                else if (message.Text == "Mol go'shtidan pishloqli lavash Standart")
                {
                    InlineKeyboardMarkup FitCombo = new(new[]
                    {
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("Mini 25 000 so'm","MiniLavash"),InlineKeyboardButton.WithCallbackData("Big 29 000 so'm","KattaLavash")
                        },

                    });
                    bot.SendPhoto(chatId, "https://ibb.co/cQ6JKc7", "Tanlang:", replyMarkup: FitCombo);
                }
                else if (message.Text == "Lavash cheese tovuq go'shtidan Standart")
                {
                    InlineKeyboardMarkup FitCombo = new(new[]
                    {
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("Mini 23 000 so'm","MiniLavashTovuq"),InlineKeyboardButton.WithCallbackData("Big 27 000 so'm","KattaLavashTovuq")
                        },

                    });
                    bot.SendPhoto(chatId, "https://ibb.co/7JmXbKR", "Tanlang:", replyMarkup: FitCombo);
                }
                else if (message.Text == "Fitter")
                {
                    InlineKeyboardMarkup FitCombo = new(new[]
                     {
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("-","-"),InlineKeyboardButton.WithCallbackData("1","1"),InlineKeyboardButton.WithCallbackData("+","+"),
                        },
                         new[]{
                             InlineKeyboardButton.WithCallbackData("📥 Savatga qo'shish","savatFitter")
                         }
                    });
                    bot.SendPhoto(chatId, "https://ibb.co/Gp1hwC6", "Tovuq goʼshti, qarsildoq muztogʼ salati, yangi bodring va pomidorlar, fetaksa va bizning maxsus qaylamiz - barchasi yashil lavashga oʼralgan.\nNarxi: 22 000 som");
                }
                else if (message.Text == "Lavash tovuq go'sht")
                {
                    InlineKeyboardMarkup FitCombo = new(new[]
                    {
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("Mini 20 000 so'm","MiniLavashTovuq"),InlineKeyboardButton.WithCallbackData("Big 24 000 so'm","KattaLavashTovuq")
                        },

                    });
                    bot.SendPhoto(chatId, "https://ibb.co/7yVdv91", "Tanlang:", replyMarkup: FitCombo);
                }
                else if (message.Text == "Lavash mol go'shtidan")
                {
                    InlineKeyboardMarkup FitCombo = new(new[]
                   {
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("Mini 22 000 so'm","MiniLavashTovuq"),InlineKeyboardButton.WithCallbackData("Big 26 000 so'm","KattaLavashTovuq")
                        },

                    });
                    bot.SendPhoto(chatId, "https://ibb.co/55Y2rBr", "Tanlang:", replyMarkup: FitCombo);
                }
                else if (message.Text == "Shaurma qalampir mol go'sht")
                {
                    InlineKeyboardMarkup FitCombo = new(new[]
                   {
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("Mini 22 000 so'm","MiniLavashTovuq"),InlineKeyboardButton.WithCallbackData("Big 26 000 so'm","KattaLavashTovuq")
                        },

                    });
                    bot.SendPhoto(chatId, "https://ibb.co/4MLpGxL", "Tanlang:", replyMarkup: FitCombo);
                }
                else if (message.Text == "Shaurma tovuq go'sht")
                {
                    InlineKeyboardMarkup FitCombo = new(new[]
                   {
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("Mini 21 000 so'm","MiniLavashTovuq"),InlineKeyboardButton.WithCallbackData("Big 24 000 so'm","KattaLavashTovuq")
                        },

                    });
                    bot.SendPhoto(chatId, "https://ibb.co/xfhNs76", "Tanlang:", replyMarkup: FitCombo);
                }
                else if (message.Text == "Shaurma qalampir tovuq go'sht")
                {
                    InlineKeyboardMarkup FitCombo = new(new[]
                   {
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("Mini 21 000 so'm","MiniLavashTovuq"),InlineKeyboardButton.WithCallbackData("Big 24 000 so'm","KattaLavashTovuq")
                        },

                    });
                    bot.SendPhoto(chatId, "https://ibb.co/xfhNs76", "Tanlang:", replyMarkup: FitCombo);
                }
                else if (message.Text == "Shaurma mol go'sht")
                {
                    InlineKeyboardMarkup FitCombo = new(new[]
                   {
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("Mini 22 000 so'm","MiniLavashTovuq"),InlineKeyboardButton.WithCallbackData("Big 26 000 so'm","KattaLavashTovuq")
                        },

                    });
                    bot.SendPhoto(chatId, "https://ibb.co/JF2GY7p", "Tanlang:", replyMarkup: FitCombo);
                }
                else if (message.Text == "Gamburger")
                {
                    InlineKeyboardMarkup FitCombo = new(new[]
                     {
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("-","-"),InlineKeyboardButton.WithCallbackData("1","1"),InlineKeyboardButton.WithCallbackData("+","+"),
                        },
                         new[]{
                             InlineKeyboardButton.WithCallbackData("📥 Savatga qo'shish","savatFitter")
                         }
                    });
                    bot.SendPhoto(chatId, "https://ibb.co/ZNww8dh", "Tabiiy mol go'shtidan shirali kotlet, yangi yetilib pishgan pomidor va marinadlangan bodringning dumaloq bo'lakchalari, Aysberg salat bargi, yumshoq, dumaloq bulochkadagi qaymoqli-tomatli sous ostida shirin, qizil piyoz halqasi\nNarxi: 22 000 som");
                }
                else if (message.Text == "Double burger")
                {
                    InlineKeyboardMarkup FitCombo = new(new[]
                     {
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("-","-"),InlineKeyboardButton.WithCallbackData("1","1"),InlineKeyboardButton.WithCallbackData("+","+"),
                        },
                         new[]{
                             InlineKeyboardButton.WithCallbackData("📥 Savatga qo'shish","savatFitter")
                         }
                    });
                    bot.SendPhoto(chatId, "https://ibb.co/NVDX9t7", "Tabiiy mol go'shtidan ikkita shirali kotlet, yangi yetilib pishgan pomidor va marinadlangan bodringning dumaloq bo'lakchalari, Aysberg salat bargi, yumshoq bulochkadagi qaymoqli-tomatli sous ostida shirin, qizil piyoz halqasi\nNarxi: 33 000 som");
                }
                else if (message.Text == "Cheese burger")
                {
                    InlineKeyboardMarkup FitCombo = new(new[]
                     {
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("-","-"),InlineKeyboardButton.WithCallbackData("1","1"),InlineKeyboardButton.WithCallbackData("+","+"),
                        },
                         new[]{
                             InlineKeyboardButton.WithCallbackData("📥 Savatga qo'shish","savatFitter")
                         }
                    });
                    bot.SendPhoto(chatId, "https://ibb.co/3CL0Q7b", "Tabiiy mol go'shtidan shirali kotlet, yangi yetilib pishgan pomidor va marinadlangan bodringning dumaloq bo'lakchalari, Aysberg salat bargi, yumshoq, dumaloq bulochkadagi qaymoqli-tomatli sous ostida Chedder pishlog'i bo'lagi\nNarxi: 24 000 som");

                }
                else if (message.Text == "Double cheese")
                {
                    InlineKeyboardMarkup FitCombo = new(new[]
                     {
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("-","-"),InlineKeyboardButton.WithCallbackData("1","1"),InlineKeyboardButton.WithCallbackData("+","+"),
                        },
                         new[]{
                             InlineKeyboardButton.WithCallbackData("📥 Savatga qo'shish","savatFitter")
                         }
                    });
                    bot.SendPhoto(chatId, "https://ibb.co/yXLb5hK", "Tabiiy mol go'shtidan ikkita shirali kotlet, yangi yetilib pishgan pomidor va marinadlangan bodringning dumaloq bo'lakchalari, Aysberg salat bargi, yumshoq, dumaloq bulochkadagi qaymoqli-tomatli sous ostida ikki bo'lak Chedder pishlog'i\nNarxi: 37 000 som");

                }
                else if(message.Text == "📞Aloqa")
                {
                    bot.SendPhoto(chatId, "https://ibb.co/94gMkrW", "Kontaktlar\r\nCall-центр\r\n\r\n+998 71-203-12-12\r\n+998 71-203-55-55\r\nYetkazib berish telefon raqamlar:\r\n\r\nToshkent\r\n+998 71-203-12-12\r\nNamangan\r\n+998 78-147-12-12\r\nFarg`ona\r\n+998 73-249-12-12\r\nQo`qon\r\n+998 73-542-78-78\r\nAndijon\r\n+998 74-224-12-12\r\nSamarqand\r\n+998 78-129-16-16\r\nQarshi\r\n+998 78-129-17-17");
                }
                else if( message.Text == "📨Xabar yuborish")
                {
                    await  bot.SendMessage(chatId, "Xabaringzini yuboring: ");
                    if(message.Text != null)
                    {
                        await bot.SendMessage(chatId, "Xabaringiz yuborildi");
                        await bot.SendMessage(chatId, "Tez orada sizga aloqaga chiqishadi");
                    }
                }

            };
            Console.ReadLine();
        }

        public static IReplyMarkup GetButtons()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ KeyboardButton.WithRequestContact("Send Phone Number📲"),new KeyboardButton{Text = "" ,} },
                    
                  
                    //new List<KeyboardButton>{ KeyboardButton.WithRequestLocation("Send Location"),new KeyboardButton{Text = ""} 
                    
                },
                ResizeKeyboard = true,
                //OneTimeKeyboard = true
            };
        }
        public static IReplyMarkup GetButtonsMenu()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton{Text = "🍴Menu" } },
                    new List<KeyboardButton>{ new KeyboardButton{Text = "📋Mening buyurtmalarim" } },
                    new List<KeyboardButton>{ new KeyboardButton{Text = "📥Savat" }  ,{new KeyboardButton {Text = "📞Aloqa" } } },
                    new List<KeyboardButton>{ new KeyboardButton{Text = "📨Xabar yuborish" }  ,{new KeyboardButton {Text = "⚙️Sozlamalar" } } },
                }
            };
        }
        public static IReplyMarkup GetFoodOnMenu()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton{Text = "Setlar" } },
                    new List<KeyboardButton>{ new KeyboardButton{Text = "Lavash" } ,new KeyboardButton{Text = "Shaurma" } },
                    new List<KeyboardButton>{ new KeyboardButton{Text = "Burger" }  ,{new KeyboardButton {Text = "Hot-Dog" } } },
                    new List<KeyboardButton>{ new KeyboardButton{Text = "Ichimliklar" }},
                    new List<KeyboardButton>{ new KeyboardButton{Text = "Shirinlik va Desertlar" }},
                    new List<KeyboardButton>{ new KeyboardButton{Text = "Garnirlar" }},
                    new List<KeyboardButton>{ new KeyboardButton{Text = "🔙Orqaga Qaytish (Menu)" } },

                }
            };
        }
        public static IReplyMarkup Setlar()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton{Text = "Combo Plus Isituvchan (Qora choy)" } , new KeyboardButton { Text = "FitCombo"} },
                    new List<KeyboardButton>{ new KeyboardButton{Text = "Iftar kofte grill mol go'shtidan" } ,new KeyboardButton{Text = "Donar boxs mol go'shtidan" } },
                    new List<KeyboardButton>{ new KeyboardButton{Text = "Donar boks tovuq go'shtidan" }  ,{new KeyboardButton {Text = "COMBO+" } } },
                    new List<KeyboardButton>{ new KeyboardButton{Text = "Iftar strips tovuq go'shtidan" }, new KeyboardButton { Text = "Kids COMBO"} },
                    new List<KeyboardButton>{ new KeyboardButton{Text = "🔙Orqaga Qaytish" } },

                }
            };
        }
        public static IReplyMarkup Lavashlar()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton{Text = "Mol go'shtidan qalampir lavash" } , new KeyboardButton { Text = "Tovuq go'shtli qalampir lavash"} },
                    new List<KeyboardButton>{ new KeyboardButton{Text = "Mol go'shtidan pishloqli lavash Standart" } ,new KeyboardButton{Text = "Lavash cheese tovuq go'shtidan Standart" } },
                    new List<KeyboardButton>{ new KeyboardButton{Text = "Fitter" }  ,{new KeyboardButton {Text = "Lavash tovuq go'sht" } } },
                    new List<KeyboardButton>{ new KeyboardButton { Text = "Lavash mol go'shtidan" } },
                    new List<KeyboardButton>{ new KeyboardButton{Text = "🔙Orqaga Qaytish" } },

                }
            };
        }
        public static IReplyMarkup Shaurmalar()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton{Text = "Shaurma qalampir mol go'sht" } , new KeyboardButton { Text = "Shaurma tovuq go'sht"} },
                    new List<KeyboardButton>{ new KeyboardButton{Text = "Shaurma qalampir tovuq go'sht" } ,new KeyboardButton{Text = "Shaurma mol go'sht" } },
                    new List<KeyboardButton>{ new KeyboardButton{Text = "🔙Orqaga Qaytish" } },

                }
            };
        }
        public static IReplyMarkup Burgerlar()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton{Text = "Gamburger" } , new KeyboardButton { Text = "Double burger"} },
                    new List<KeyboardButton>{ new KeyboardButton{Text = "Cheese burger" } ,new KeyboardButton{Text = "Double cheese" } },
                    new List<KeyboardButton>{ new KeyboardButton{Text = "🔙Orqaga Qaytish" } },

                }
            };
        }
        public static IReplyMarkup Shirinlik()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton{Text = "Medovik Asalim" } , new KeyboardButton { Text = "Chizkeyk"} },
                    new List<KeyboardButton>{ new KeyboardButton{Text = "Donut aramelli" } ,new KeyboardButton{Text = "Donut mevali" } },
                    new List<KeyboardButton>{ new KeyboardButton{Text = "🔙Orqaga Qaytish" } },

                }
            };
        }
        public static IReplyMarkup HotDoglar()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton{Text = "Hot-Dog baguette" } , new KeyboardButton { Text = "Sub tovuq cheese"} },
                    new List<KeyboardButton>{ new KeyboardButton{Text = "Sub tovuq" } ,new KeyboardButton{Text = "Hot-Dog baguette double" } },
                    new List<KeyboardButton>{ new KeyboardButton{Text = "Hot-Dog cheese" } ,new KeyboardButton{Text = "Sub go'sht cheese" } },
                    new List<KeyboardButton>{ new KeyboardButton{Text = "Hot-Dog classic" } ,new KeyboardButton{Text = "Sub go'sht" } },
                    new List<KeyboardButton>{ new KeyboardButton{Text = "🔙Orqaga Qaytish" } },

                }
            };
        }
        public static IReplyMarkup Suv()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton{Text = "Sok dena 0,33L" } , new KeyboardButton { Text = "Suv 0,5"} },
                    new List<KeyboardButton>{ new KeyboardButton{Text = "Pepsi 0,5" } ,new KeyboardButton{Text = "Pepsi 1,5" } },
                    new List<KeyboardButton>{ new KeyboardButton{Text = "Quyib beriladigan Pepsi" } ,new KeyboardButton{Text = "Bliss sharbat" } },
                    new List<KeyboardButton>{ new KeyboardButton{Text = "Ko'k choy" } ,new KeyboardButton{Text = "Qora choy" } },
                    new List<KeyboardButton>{ new KeyboardButton{Text = "Limonli ko'k choy" } },
                    new List<KeyboardButton>{ new KeyboardButton{Text = "🔙Orqaga Qaytish" } },
                }
            };
        }
        public static IReplyMarkup Snack()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton{Text = "Ketchup" } , new KeyboardButton { Text = "Guruch"} },
                    new List<KeyboardButton>{ new KeyboardButton{Text = "Po-derevenski" } ,new KeyboardButton{Text = "Sarimsoqli qayla" } },
                    new List<KeyboardButton>{ new KeyboardButton{Text = "Chili qayalasi" } ,new KeyboardButton{Text = "Mayonez" } },
                    new List<KeyboardButton>{ new KeyboardButton{Text = "Salat" } ,new KeyboardButton{Text = "Sarimsoqli qayla" } },
                    new List<KeyboardButton>{ new KeyboardButton{Text = "Limonli ko'k choy" } , new KeyboardButton { Text = "Sir qaylasi"} },
                    new List<KeyboardButton>{ new KeyboardButton{Text = "Tovuq Strips" } , new KeyboardButton { Text = "Fri"} },
                    new List<KeyboardButton>{ new KeyboardButton{Text = "🔙Orqaga Qaytish" } },
                }
            };
        }

        public static async Task HandCallBack(ITelegramBotClient bot, CallbackQuery callbackQuery)
        {

            if (callbackQuery.Data == "Kanal_1")
            {
                bot.SendMessage(callbackQuery.Message.Id, """
        🥳Tabriklaymiz!!! Sizga 🎁50% chegirma taqdim etildi.

        📑Promokodingiz: EVOS1707890 nusxalab botga yuboring.
        /start ni bosing!
        """);

            }
        }
        public class UserInfo
        {
            public string UserName { get; set; }
            public string Contact { get; set; }
        }
        public static void Writer(List<UserInfo> userInfo, string path)
        {
            using (StreamWriter sr = new StreamWriter(path))
            {
                foreach (var item in userInfo)
                {
                    sr.WriteLine(item.UserName);
                    sr.WriteLine(item.Contact);
                }
            }
        }
        public static void JsonWriter(List<UserInfo> userInfo)
        {
            JsonSerializer.Serialize(userInfo.ToString());
        }

    }
}
