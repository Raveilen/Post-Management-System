using PostManagementSystem.Models;

namespace PostManagementSystem.Data
{
    public class DbInitializer
    {

        public static void Seed(PostManagementContext context)
        {
            //Cities
            if (context.Cities.Any())
            {
                return;
            }

            var cities = new City[]
            {
                new City { Name = "Warszawa" },
                new City { Name = "Kraków" },
                new City { Name = "Wrocław" },
                new City { Name = "Poznań" },
                new City { Name = "Gdańsk" },
                new City { Name = "Szczecin" },
                new City { Name = "Bydgoszcz" },
                new City { Name = "Lublin" },
                new City { Name = "Katowice" },
                new City { Name = "Białystok" },
                new City { Name = "Gdynia" },
                new City { Name = "Częstochowa" },
                new City { Name = "Łódź" }
            };

            foreach (var city in cities)
            {
                context.Cities.Add(city);
            }

            context.SaveChanges();


            //Addresses
            if (context.Addresses.Any())
            {
                return;
            }

            var addresses = new Address[]
            {
                new Address { Street = "Nowy Świat", DwellingNumber = "18", ApartmentNumber = "12", PostalCode = "00-372", City = cities.Single(c => c.Name == "Warszawa"), CityID = cities.Single(c => c.Name == "Warszawa").CityID },
                new Address { Street = "Floriańska", DwellingNumber = "5", ApartmentNumber = "21", PostalCode = "31-019", City = cities.Single(c => c.Name == "Kraków"), CityID = cities.Single(c => c.Name == "Kraków").CityID },
                new Address { Street = "Świdnicka", DwellingNumber = "32", ApartmentNumber = "7", PostalCode = "50-068", City = cities.Single(c => c.Name == "Wrocław"), CityID = cities.Single(c => c.Name == "Wrocław").CityID },
                new Address { Street = "Półwiejska", ApartmentNumber = "4", PostalCode = "61-888", City = cities.Single(c => c.Name == "Poznań"), CityID = cities.Single(c => c.Name == "Poznań").CityID },
                new Address { Street = "Długa", DwellingNumber = "8", ApartmentNumber = "15", PostalCode = "80-831", City = cities.Single(c => c.Name == "Gdańsk"), CityID = cities.Single(c => c.Name == "Gdańsk").CityID },
                new Address { Street = "Aleja Wyzwolenia", DwellingNumber = "20", PostalCode = "70-531", City = cities.Single(c => c.Name == "Szczecin"), CityID = cities.Single(c => c.Name == "Szczecin").CityID },
                new Address { Street = "Gdańska", DwellingNumber = "27", ApartmentNumber = "10", PostalCode = "85-005", City = cities.Single(c => c.Name == "Bydgoszcz"), CityID = cities.Single(c => c.Name == "Bydgoszcz").CityID },
                new Address { Street = "Krakowskie Przedmieście", DwellingNumber = "45", PostalCode = "20-002", City = cities.Single(c => c.Name == "Lublin"), CityID = cities.Single(c => c.Name == "Lublin").CityID },
                new Address { Street = "Mariacka", DwellingNumber = "12", ApartmentNumber = "4", PostalCode = "40-014", City = cities.Single(c => c.Name == "Katowice"), CityID = cities.Single(c => c.Name == "Katowice").CityID },
                new Address { Street = "Lipowa", DwellingNumber = "6", PostalCode = "15-424", City = cities.Single(c => c.Name == "Białystok"), CityID = cities.Single(c => c.Name == "Białystok").CityID },
                new Address { Street = "Świętojańska", DwellingNumber = "15", ApartmentNumber = "9", PostalCode = "81-368", City = cities.Single(c => c.Name == "Gdynia"), CityID = cities.Single(c => c.Name == "Gdynia").CityID },
                new Address { Street = "Aleja Najświętszej Maryi Panny", ApartmentNumber = "11", PostalCode = "42-200", City = cities.Single(c => c.Name == "Częstochowa"), CityID = cities.Single(c => c.Name == "Częstochowa").CityID },
                new Address { Street = "Piotrkowska", DwellingNumber = "104", ApartmentNumber = "22", PostalCode = "90-001", City = cities.Single(c => c.Name == "Łódź"), CityID = cities.Single(c => c.Name == "Łódź").CityID },

                new Address { Street = "Mokotowska", DwellingNumber = "45", ApartmentNumber = "9", PostalCode = "00-542", City = cities.Single(c => c.Name == "Warszawa"), CityID = cities.Single(c => c.Name == "Warszawa").CityID },
                new Address { Street = "Grodzka", DwellingNumber = "22", PostalCode = "31-006", City = cities.Single(c => c.Name == "Kraków"), CityID = cities.Single(c => c.Name == "Kraków").CityID },
                new Address { Street = "Oławska", DwellingNumber = "3", ApartmentNumber = "2", PostalCode = "50-123", City = cities.Single(c => c.Name == "Wrocław"), CityID = cities.Single(c => c.Name == "Wrocław").CityID },
                new Address { Street = "Święty Marcin", ApartmentNumber = "18", PostalCode = "61-807", City = cities.Single(c => c.Name == "Poznań"), CityID = cities.Single(c => c.Name == "Poznań").CityID },
                new Address { Street = "Chmielna", DwellingNumber = "10", ApartmentNumber = "5", PostalCode = "80-748", City = cities.Single(c => c.Name == "Gdańsk"), CityID = cities.Single(c => c.Name == "Gdańsk").CityID },
                new Address { Street = "Jagiellońska", DwellingNumber = "13", PostalCode = "70-362", City = cities.Single(c => c.Name == "Szczecin"), CityID = cities.Single(c => c.Name == "Szczecin").CityID },
                new Address { Street = "Dworcowa", DwellingNumber = "6", ApartmentNumber = "8", PostalCode = "85-009", City = cities.Single(c => c.Name == "Bydgoszcz"), CityID = cities.Single(c => c.Name == "Bydgoszcz").CityID },
                new Address { Street = "Narutowicza", DwellingNumber = "37", PostalCode = "20-016", City = cities.Single(c => c.Name == "Lublin"), CityID = cities.Single(c => c.Name == "Lublin").CityID },
                new Address { Street = "Kościuszki", DwellingNumber = "8", ApartmentNumber = "3", PostalCode = "40-049", City = cities.Single(c => c.Name == "Katowice"), CityID = cities.Single(c => c.Name == "Katowice").CityID },
                new Address { Street = "Rynek Kościuszki", DwellingNumber = "5", PostalCode = "15-426", City = cities.Single(c => c.Name == "Białystok"), CityID = cities.Single(c => c.Name == "Białystok").CityID },
                new Address { Street = "Starowiejska", DwellingNumber = "23", ApartmentNumber = "14", PostalCode = "81-363", City = cities.Single(c => c.Name == "Gdynia"), CityID = cities.Single(c => c.Name == "Gdynia").CityID },
                new Address { Street = "Jasnogórska", DwellingNumber = "12", PostalCode = "42-200", City = cities.Single(c => c.Name == "Częstochowa"), CityID = cities.Single(c => c.Name == "Częstochowa").CityID },
                new Address { Street = "Narutowicza", DwellingNumber = "64", ApartmentNumber = "6", PostalCode = "90-135", City = cities.Single(c => c.Name == "Łódź"), CityID = cities.Single(c => c.Name == "Łódź").CityID }
            };

            foreach (var address in addresses)
            {
                context.Addresses.Add(address);
            }

            context.SaveChanges();


            //PostOffices
            if (context.PostOffices.Any())
            {
                return;
            }

            var postOffices = new PostOffice[]
            {
                new PostOffice { packageSCapacity = 10, packageMCapacity = 15, packageLCapacity = 5, Address = addresses.Single(a => a.Street == "Nowy Świat"), AddressID = addresses.Single(a => a.Street == "Nowy Świat").AddressID },
                new PostOffice { packageSCapacity = 8, packageMCapacity = 14, packageLCapacity = 8, Address = addresses.Single(a => a.Street == "Floriańska"), AddressID = addresses.Single(a => a.Street == "Floriańska").AddressID },
                new PostOffice { packageSCapacity = 10, packageMCapacity = 15, packageLCapacity = 12, Address = addresses.Single(a => a.Street == "Świdnicka"), AddressID = addresses.Single(a => a.Street == "Świdnicka").AddressID },
                new PostOffice { packageSCapacity = 18, packageMCapacity = 9, packageLCapacity = 5, Address = addresses.Single(a => a.Street == "Półwiejska"), AddressID = addresses.Single(a => a.Street == "Półwiejska").AddressID },
                new PostOffice { packageSCapacity = 30, packageMCapacity = 15, packageLCapacity = 3, Address = addresses.Single(a => a.Street == "Długa"), AddressID = addresses.Single(a => a.Street == "Długa").AddressID },
                new PostOffice { packageSCapacity = 20, packageMCapacity = 10, packageLCapacity = 6, Address = addresses.Single(a => a.Street == "Aleja Wyzwolenia"), AddressID = addresses.Single(a => a.Street == "Aleja Wyzwolenia").AddressID },
                new PostOffice { packageSCapacity = 10, packageMCapacity = 5, packageLCapacity = 7, Address = addresses.Single(a => a.Street == "Gdańska"), AddressID = addresses.Single(a => a.Street == "Gdańska").AddressID },
                new PostOffice { packageSCapacity = 5, packageMCapacity = 2, packageLCapacity = 6, Address = addresses.Single(a => a.Street == "Krakowskie Przedmieście"), AddressID = addresses.Single(a => a.Street == "Krakowskie Przedmieście").AddressID },
                new PostOffice { packageSCapacity = 10, packageMCapacity = 15, packageLCapacity = 9, Address = addresses.Single(a => a.Street == "Mokotowska"), AddressID = addresses.Single(a => a.Street == "Mokotowska").AddressID },
                new PostOffice { packageSCapacity = 9, packageMCapacity = 14, packageLCapacity = 4, Address = addresses.Single(a => a.Street == "Grodzka"), AddressID = addresses.Single(a => a.Street == "Grodzka").AddressID },
                new PostOffice { packageSCapacity = 16, packageMCapacity = 13, packageLCapacity = 10, Address = addresses.Single(a => a.Street == "Oławska"), AddressID = addresses.Single(a => a.Street == "Oławska").AddressID },
                new PostOffice { packageSCapacity = 12, packageMCapacity = 12, packageLCapacity = 5, Address = addresses.Single(a => a.Street == "Święty Marcin"), AddressID = addresses.Single(a => a.Street == "Święty Marcin").AddressID }
            };

            foreach (var postOffice in postOffices)
            {
                context.PostOffices.Add(postOffice);
            }

            context.SaveChanges();


            //Statuses
            if (context.Statuses.Any())
            {
                return;
            }

            var loadImageTest = ImageConverter.ConvertImageToByteArray("~/assets/img/Ordered.png");
            var statuses = new Status[]
            {
                new Status { Name = "Ordered", Image = ImageConverter.ConvertImageToByteArray("~/assets/img/Ordered.png")},
                new Status { Name = "Packed", Image = ImageConverter.ConvertImageToByteArray("~/assets/img/Packed.png")},
                new Status { Name = "In Transit", Image = ImageConverter.ConvertImageToByteArray("~/assets/img/InTransit.png") },
                new Status { Name = "Delivered", Image = ImageConverter.ConvertImageToByteArray("~/assets/img/Delivered.png") },
                new Status { Name = "Collected", Image = ImageConverter.ConvertImageToByteArray("~/assets/img/Collected.png")},
                new Status { Name = "Returned", Image = ImageConverter.ConvertImageToByteArray("~/assets/img/Returned.png") }
            };

            foreach (var status in statuses)
            {
                context.Statuses.Add(status);
            }

            context.SaveChanges();

            //PackageTypes
            if (context.PackageTypes.Any())
            {
                return;
            }

            var packageTypes = new PackageType[]
            {
                new PackageType { Name = "Small", MaxWeight = 25, MaxDimensions = "8x38x64", IsFragile = false, Cost = 16.99m, Image = ImageConverter.ConvertImageToByteArray("~/assets/img/Small.png")},
                new PackageType { Name = "Medium", MaxWeight = 25, MaxDimensions = "19x38x64", IsFragile = false, Cost = 18.99m, Image = ImageConverter.ConvertImageToByteArray("~/assets/img/Medium.png") },
                new PackageType { Name = "Large", MaxWeight = 25, MaxDimensions = "41x38x64", IsFragile = false, Cost = 20.99m, Image = ImageConverter.ConvertImageToByteArray("~/assets/img/Large.png") },

                new PackageType { Name = "Small", MaxWeight = 25, MaxDimensions = "8x38x64", IsFragile = true, Cost = 19.99m, Image = ImageConverter.ConvertImageToByteArray("~/assets/img/Small.png")},
                new PackageType { Name = "Medium", MaxWeight = 25, MaxDimensions = "19x38x64", IsFragile = true, Cost = 21.99m, Image = ImageConverter.ConvertImageToByteArray("~/assets/img/Medium.png") },
                new PackageType { Name = "Large", MaxWeight = 25, MaxDimensions = "41x38x64", IsFragile = true, Cost = 23.99m, Image = ImageConverter.ConvertImageToByteArray("~/assets/img/Large.png") }
            };

            foreach (var packageType in packageTypes)
            {
                context.PackageTypes.Add(packageType);
            }

            context.SaveChanges();

            //Customers
            if (context.Customers.Any())
            {
                return;
            }

            var customers = new Customer[]
            {
                new Customer { Name = "Jan", Surname = "Kowalski", Email = "jankowalski@gmail.com", Phone = "568749852", },
                new Customer { Name = "Anna", Surname = "Nowak", Email = "annanowak@grupaonet.com", Phone = "512345678" },
                new Customer { Name = "Tomasz", Surname = "Wiśniewski", Email = "tomasz.wisniewski@wp.pl", Phone = "523456789" },
                new Customer { Name = "Katarzyna", Surname = "Kaczmarek", Email = "katarzyna.kaczmarek@yahoo.com", Phone = "534567890" },
                new Customer { Name = "Paweł", Surname = "Zieliński", Email = "pawel.zielinski@grupaonet.com", Phone = "545678901" },
                new Customer { Name = "Monika", Surname = "Jankowska", Email = "monika.jankowska@wp.pl", Phone = "556789012" },
                new Customer { Name = "Marek", Surname = "Szymański", Email = "marek.szymanski@yahoo.com", Phone = "567890123" },
                new Customer { Name = "Agnieszka", Surname = "Wróbel", Email = "agnieszka.wrobel@grupaonet.com", Phone = "578901234" },
                new Customer { Name = "Łukasz", Surname = "Michalski", Email = "lukasz.michalski@wp.pl", Phone = "589012345" },
                new Customer { Name = "Justyna", Surname = "Krawczyk", Email = "justyna.krawczyk@yahoo.com", Phone = "590123456" },
                new Customer { Name = "Grzegorz", Surname = "Borkowski", Email = "grzegorz.borkowski@grupaonet.com", Phone = "601234567" },
                new Customer { Name = "Ewa", Surname = "Kubiak", Email = "ewa.kubiak@wp.pl", Phone = "612345678" },
                new Customer { Name = "Piotr", Surname = "Dąbrowski", Email = "piotr.dabrowski@yahoo.com", Phone = "623456789" },
                new Customer { Name = "Karolina", Surname = "Zawisza", Email = "karolina.zawisza@grupaonet.com", Phone = "634567890" },
                new Customer { Name = "Adam", Surname = "Pawlak", Email = "adam.pawlak@wp.pl", Phone = "645678901" },
                new Customer { Name = "Marta", Surname = "Wojciechowska", Email = "marta.wojciechowska@yahoo.com", Phone = "656789012" },

                new Customer { Name = "Julia", Surname = "Lewandowska", Email = "julia.lewandowska@grupaonet.com", Phone = "667890123" },
                new Customer { Name = "Michał", Surname = "Czarnecki", Email = "michal.czarnecki@wp.pl", Phone = "678901234" },
                new Customer { Name = "Natalia", Surname = "Bąk", Email = "natalia.bak@yahoo.com", Phone = "689012345" },
                new Customer { Name = "Krzysztof", Surname = "Kamiński", Email = "krzysztof.kaminski@grupaonet.com", Phone = "690123456" },
                new Customer { Name = "Ola", Surname = "Wysocka", Email = "ola.wysocka@wp.pl", Phone = "701234567" },
                new Customer { Name = "Sebastian", Surname = "Nowicki", Email = "sebastian.nowicki@yahoo.com", Phone = "712345678" },
                new Customer { Name = "Aleksandra", Surname = "Marciniak", Email = "aleksandra.marciniak@grupaonet.com", Phone = "723456789" },
                new Customer { Name = "Dariusz", Surname = "Kozłowski", Email = "dariusz.kozlowski@wp.pl", Phone = "734567890" },
                new Customer { Name = "Wioleta", Surname = "Pietrzak", Email = "wioleta.pietrzak@yahoo.com", Phone = "745678901" },
                new Customer { Name = "Andrzej", Surname = "Sikora", Email = "andrzej.sikora@grupaonet.com", Phone = "756789012" },
                new Customer { Name = "Zofia", Surname = "Kalinowska", Email = "zofia.kalinowska@wp.pl", Phone = "767890123" },
                new Customer { Name = "Rafał", Surname = "Mazurek", Email = "rafal.mazurek@yahoo.com", Phone = "778901234" },
                new Customer { Name = "Edyta", Surname = "Różalska", Email = "edyta.rozalska@grupaonet.com", Phone = "789012345" },
                new Customer { Name = "Waldemar", Surname = "Sadowski", Email = "waldemar.sadowski@wp.pl", Phone = "790123456" },
                new Customer { Name = "Kinga", Surname = "Wasilewska", Email = "kinga.wasilewska@yahoo.com", Phone = "801234567" },

            };



            foreach (var customer in customers)
            {
                context.Customers.Add(customer);
            }

            context.SaveChanges();

            //Packages
            if (context.Packages.Any())
            {
                return;
            }

            var Packages = new Package[]
            {
                new Package { 
                    Sender = customers.Single(c => c.Name == "Jan" && c.Surname == "Kowalski"), 
                    SenderID = customers.Single(c => c.Name == "Jan" && c.Surname == "Kowalski").ID,
                    Receiver = customers.Single(c => c.Name == "Anna" && c.Surname == "Nowak"),
                    ReceiverID = customers.Single(c => c.Name == "Anna" && c.Surname == "Nowak").ID,
                    Type = packageTypes.Single(p => p.Name == "Small" && p.IsFragile == false),
                    PackageTypeID = packageTypes.Single(p => p.Name == "Small" && p.IsFragile == false).PackageTypeID },

                new Package { Sender = customers.Single(c => c.Name == "Tomasz" && c.Surname == "Wiśniewski"),
                    SenderID = customers.Single(c => c.Name == "Tomasz" && c.Surname == "Wiśniewski").ID,
                    Receiver = customers.Single(c => c.Name == "Katarzyna" && c.Surname == "Kaczmarek"),
                    ReceiverID = customers.Single(c => c.Name == "Katarzyna" && c.Surname == "Kaczmarek").ID,
                    Type = packageTypes.Single(p => p.Name == "Medium" && p.IsFragile == false),
                    PackageTypeID = packageTypes.Single(p => p.Name == "Medium" && p.IsFragile == false).PackageTypeID },
                new Package { Sender = customers.Single(c => c.Name == "Paweł" && c.Surname == "Zieliński"), SenderID = customers.Single(c => c.Name == "Paweł" && c.Surname == "Zieliński").ID, Receiver = customers.Single(c => c.Name == "Monika" && c.Surname == "Jankowska"), ReceiverID = customers.Single(c => c.Name == "Monika" && c.Surname == "Jankowska").ID, Type = packageTypes.Single(p => p.Name == "Large" && p.IsFragile == false), PackageTypeID = packageTypes.Single(p => p.Name == "Large" && p.IsFragile == false).PackageTypeID },
                new Package { Sender = customers.Single(c => c.Name == "Marek" && c.Surname == "Szymański"), SenderID = customers.Single(c => c.Name == "Marek" && c.Surname == "Szymański").ID, Receiver = customers.Single(c => c.Name == "Agnieszka" && c.Surname == "Wróbel"), ReceiverID = customers.Single(c => c.Name == "Agnieszka" && c.Surname == "Wróbel").ID, Type = packageTypes.Single(p => p.Name == "Small" && p.IsFragile == true), PackageTypeID = packageTypes.Single(p => p.Name == "Small" && p.IsFragile == true).PackageTypeID },
                new Package { Sender = customers.Single(c => c.Name == "Łukasz" && c.Surname == "Michalski"), SenderID = customers.Single(c => c.Name == "Łukasz" && c.Surname == "Michalski").ID, Receiver = customers.Single(c => c.Name == "Justyna" && c.Surname == "Krawczyk"), ReceiverID = customers.Single(c => c.Name == "Justyna" && c.Surname == "Krawczyk").ID, Type = packageTypes.Single(p => p.Name == "Medium" && p.IsFragile == true), PackageTypeID = packageTypes.Single(p => p.Name == "Medium" && p.IsFragile == true).PackageTypeID },
                new Package { Sender = customers.Single(c => c.Name == "Grzegorz" && c.Surname == "Borkowski"), SenderID = customers.Single(c => c.Name == "Grzegorz" && c.Surname == "Borkowski").ID, Receiver = customers.Single(c => c.Name == "Ewa" && c.Surname == "Kubiak"), ReceiverID = customers.Single(c => c.Name == "Ewa" && c.Surname == "Kubiak").ID, Type = packageTypes.Single(p => p.Name == "Large" && p.IsFragile == true), PackageTypeID = packageTypes.Single(p => p.Name == "Large" && p.IsFragile == true).PackageTypeID },
                new Package { Sender = customers.Single(c => c.Name == "Piotr" && c.Surname == "Dąbrowski"), SenderID = customers.Single(c => c.Name == "Piotr" && c.Surname == "Dąbrowski").ID, Receiver = customers.Single(c => c.Name == "Karolina" && c.Surname == "Zawisza"), ReceiverID = customers.Single(c => c.Name == "Karolina" && c.Surname == "Zawisza").ID, Type = packageTypes.Single(p => p.Name == "Small" && p.IsFragile == false), PackageTypeID = packageTypes.Single(p => p.Name == "Small" && p.IsFragile == false).PackageTypeID },
                new Package { Sender = customers.Single(c => c.Name == "Adam" && c.Surname == "Pawlak"), SenderID = customers.Single(c => c.Name == "Adam" && c.Surname == "Pawlak").ID, Receiver = customers.Single(c => c.Name == "Marta" && c.Surname == "Wojciechowska"), ReceiverID = customers.Single(c => c.Name == "Marta" && c.Surname == "Wojciechowska").ID, Type = packageTypes.Single(p => p.Name == "Medium" && p.IsFragile == false), PackageTypeID = packageTypes.Single(p => p.Name == "Medium" && p.IsFragile == false).PackageTypeID },
                new Package { Sender = customers.Single(c => c.Name == "Julia" && c.Surname == "Lewandowska"), SenderID = customers.Single(c => c.Name == "Julia" && c.Surname == "Lewandowska").ID, Receiver = customers.Single(c => c.Name == "Michał" && c.Surname == "Czarnecki"), ReceiverID = customers.Single(c => c.Name == "Michał" && c.Surname == "Czarnecki").ID, Type = packageTypes.Single(p => p.Name == "Large" && p.IsFragile == false), PackageTypeID = packageTypes.Single(p => p.Name == "Large" && p.IsFragile == false).PackageTypeID },
                new Package { Sender = customers.Single(c => c.Name == "Natalia" && c.Surname == "Bąk"), SenderID = customers.Single(c => c.Name == "Natalia" && c.Surname == "Bąk").ID, Receiver = customers.Single(c => c.Name == "Krzysztof" && c.Surname == "Kamiński"), ReceiverID = customers.Single(c => c.Name == "Krzysztof" && c.Surname == "Kamiński").ID, Type = packageTypes.Single(p => p.Name == "Small" && p.IsFragile == true), PackageTypeID = packageTypes.Single(p => p.Name == "Small" && p.IsFragile == true).PackageTypeID },
                new Package { Sender = customers.Single(c => c.Name == "Ola" && c.Surname == "Wysocka"), SenderID = customers.Single(c => c.Name == "Ola" && c.Surname == "Wysocka").ID, Receiver = customers.Single(c => c.Name == "Sebastian" && c.Surname == "Nowicki"), ReceiverID = customers.Single(c => c.Name == "Sebastian" && c.Surname == "Nowicki").ID, Type = packageTypes.Single(p => p.Name == "Medium" && p.IsFragile == true), PackageTypeID = packageTypes.Single(p => p.Name == "Medium" && p.IsFragile == true).PackageTypeID },
                new Package { Sender = customers.Single(c => c.Name == "Aleksandra" && c.Surname == "Marciniak"), SenderID = customers.Single(c => c.Name == "Aleksandra" && c.Surname == "Marciniak").ID, Receiver = customers.Single(c => c.Name == "Dariusz" && c.Surname == "Kozłowski"), ReceiverID = customers.Single(c => c.Name == "Dariusz" && c.Surname == "Kozłowski").ID, Type = packageTypes.Single(p => p.Name == "Large" && p.IsFragile == true), PackageTypeID = packageTypes.Single(p => p.Name == "Large" && p.IsFragile == true).PackageTypeID },
                new Package { Sender = customers.Single(c => c.Name == "Wioleta" && c.Surname == "Pietrzak"), SenderID = customers.Single(c => c.Name == "Wioleta" && c.Surname == "Pietrzak").ID, Receiver = customers.Single(c => c.Name == "Andrzej" && c.Surname == "Sikora"), ReceiverID = customers.Single(c => c.Name == "Andrzej" && c.Surname == "Sikora").ID, Type = packageTypes.Single(p => p.Name == "Small" && p.IsFragile == false), PackageTypeID = packageTypes.Single(p => p.Name == "Small" && p.IsFragile == false).PackageTypeID },
                new Package { Sender = customers.Single(c => c.Name == "Zofia" && c.Surname == "Kalinowska"), SenderID = customers.Single(c => c.Name == "Zofia" && c.Surname == "Kalinowska").ID, Receiver = customers.Single(c => c.Name == "Rafał" && c.Surname == "Mazurek"), ReceiverID = customers.Single(c => c.Name == "Rafał" && c.Surname == "Mazurek").ID, Type = packageTypes.Single(p => p.Name == "Medium" && p.IsFragile == false), PackageTypeID = packageTypes.Single(p => p.Name == "Medium" && p.IsFragile == false).PackageTypeID },
                new Package { Sender = customers.Single(c => c.Name == "Edyta" && c.Surname == "Różalska"), SenderID = customers.Single(c => c.Name == "Edyta" && c.Surname == "Różalska").ID, Receiver = customers.Single(c => c.Name == "Waldemar" && c.Surname == "Sadowski"), ReceiverID = customers.Single(c => c.Name == "Waldemar" && c.Surname == "Sadowski").ID, Type = packageTypes.Single(p => p.Name == "Large" && p.IsFragile == false), PackageTypeID = packageTypes.Single(p => p.Name == "Large" && p.IsFragile == false).PackageTypeID },
                new Package { Sender = customers.Single(c => c.Name == "Kinga" && c.Surname == "Wasilewska"), SenderID = customers.Single(c => c.Name == "Kinga" && c.Surname == "Wasilewska").ID, Receiver = customers.Single(c => c.Name == "Adam" && c.Surname == "Pawlak"), ReceiverID = customers.Single(c => c.Name == "Adam" && c.Surname == "Pawlak").ID, Type = packageTypes.Single(p => p.Name == "Small" && p.IsFragile == true), PackageTypeID = packageTypes.Single(p => p.Name == "Small" && p.IsFragile == true).PackageTypeID }
            };

            foreach (var package in Packages)
            {
                context.Packages.Add(package);
            }

            context.SaveChanges();


            //Deliveries
            if (context.Deliveries.Any())
            {
                return;
            }

            var deliveries = new Delivery[]
            {
                new Delivery {
                    CreatedDate = DateTime.Parse("2024-08-24 12:35:00"),
                    ExpectedDeliveryDate = DateTime.Parse("2024-08-27 18:00:00"),
                    StatusUpdateDate = DateTime.Parse("2024-08-24 12:42:00"),
                    Package = Packages.Single(p => p.Sender.Name == "Jan" && p.Sender.Surname == "Kowalski"),
                    PackageID = Packages.Single(p => p.Sender.Name == "Jan" && p.Sender.Surname == "Kowalski").ID,
                    SenderPostOffice = postOffices.Single(po => po.Address.Street == "Nowy Świat"),
                    SenderPostOfficeID = postOffices.Single(po => po.Address.Street == "Nowy Świat").PostOfficeID,
                    ReceiverPostOffice = postOffices.Single(po => po.Address.Street == "Grodzka"),
                    ReceiverPostOfficeID = postOffices.Single(po => po.Address.Street == "Gordzka").PostOfficeID,
                    Status = statuses.Single(s => s.Name == "Ordered"),
                    StatusID = statuses.Single(s => s.Name == "Ordered").StatusID },
                new Delivery {
                    CreatedDate = DateTime.Parse("2024-08-22 09:15:00"),
                    ExpectedDeliveryDate = DateTime.Parse("2024-08-25 17:00:00"),
                    StatusUpdateDate = DateTime.Parse("2024-08-22 09:30:00"),
                    Package = Packages.Single(p => p.Sender.Name == "Anna" && p.Sender.Surname == "Nowak"),
                    PackageID = Packages.Single(p => p.Sender.Name == "Anna" && p.Sender.Surname == "Nowak").ID,
                    SenderPostOffice = postOffices.Single(po => po.Address.Street == "Mokotowska"),
                    SenderPostOfficeID = postOffices.Single(po => po.Address.Street == "Mokotowska").PostOfficeID,
                    ReceiverPostOffice = postOffices.Single(po => po.Address.Street == "Grodzka"),
                    ReceiverPostOfficeID = postOffices.Single(po => po.Address.Street == "Grodzka").PostOfficeID,
                    Status = statuses.Single(s => s.Name == "Packed"),
                    StatusID = statuses.Single(s => s.Name == "Packed").StatusID },
                new Delivery {
                    CreatedDate = DateTime.Parse("2024-08-23 10:05:00"),
                    ExpectedDeliveryDate = DateTime.Parse("2024-08-26 15:00:00"),
                    StatusUpdateDate = DateTime.Parse("2024-08-23 10:20:00"),
                    Package = Packages.Single(p => p.Sender.Name == "Tomasz" && p.Sender.Surname == "Wiśniewski"),
                    PackageID = Packages.Single(p => p.Sender.Name == "Tomasz" && p.Sender.Surname == "Wiśniewski").ID,
                    SenderPostOffice = postOffices.Single(po => po.Address.Street == "Floriańska"),
                    SenderPostOfficeID = postOffices.Single(po => po.Address.Street == "Floriańska").PostOfficeID,
                    ReceiverPostOffice = postOffices.Single(po => po.Address.Street == "Świdnicka"),
                    ReceiverPostOfficeID = postOffices.Single(po => po.Address.Street == "Świdnicka").PostOfficeID,
                    Status = statuses.Single(s => s.Name == "In Transit"),
                    StatusID = statuses.Single(s => s.Name == "In Transit").StatusID
},

                new Delivery {
                    CreatedDate = DateTime.Parse("2024-08-24 08:45:00"),
                    ExpectedDeliveryDate = DateTime.Parse("2024-08-27 12:00:00"),
                    StatusUpdateDate = DateTime.Parse("2024-08-24 09:00:00"),
                    Package = Packages.Single(p => p.Sender.Name == "Katarzyna" && p.Sender.Surname == "Kaczmarek"),
                    PackageID = Packages.Single(p => p.Sender.Name == "Katarzyna" && p.Sender.Surname == "Kaczmarek").ID,
                    SenderPostOffice = postOffices.Single(po => po.Address.Street == "Oławska"),
                    SenderPostOfficeID = postOffices.Single(po => po.Address.Street == "Oławska").PostOfficeID,
                    ReceiverPostOffice = postOffices.Single(po => po.Address.Street == "Półwiejska"),
                    ReceiverPostOfficeID = postOffices.Single(po => po.Address.Street == "Półwiejska").PostOfficeID,
                    Status = statuses.Single(s => s.Name == "Delivered"),
                    StatusID = statuses.Single(s => s.Name == "Delivered").StatusID },

                new Delivery {
                    CreatedDate = DateTime.Parse("2024-08-25 11:25:00"),
                    ExpectedDeliveryDate = DateTime.Parse("2024-08-28 16:00:00"),
                    StatusUpdateDate = DateTime.Parse("2024-08-25 11:45:00"),
                    Package = Packages.Single(p => p.Sender.Name == "Paweł" && p.Sender.Surname == "Zieliński"),
                    PackageID = Packages.Single(p => p.Sender.Name == "Paweł" && p.Sender.Surname == "Zieliński").ID,
                    SenderPostOffice = postOffices.Single(po => po.Address.Street == "Długa"),
                    SenderPostOfficeID = postOffices.Single(po => po.Address.Street == "Długa").PostOfficeID,
                    ReceiverPostOffice = postOffices.Single(po => po.Address.Street == "Aleja Wyzwolenia"),
                    ReceiverPostOfficeID = postOffices.Single(po => po.Address.Street == "Aleja Wyzwolenia").PostOfficeID,
                    Status = statuses.Single(s => s.Name == "Collected"),
                    StatusID = statuses.Single(s => s.Name == "Collected").StatusID },

                new Delivery {
                    CreatedDate = DateTime.Parse("2024-08-21 14:00:00"),
                    ExpectedDeliveryDate = DateTime.Parse("2024-08-24 19:00:00"),
                    StatusUpdateDate = DateTime.Parse("2024-08-21 14:20:00"),
                    Package = Packages.Single(p => p.Sender.Name == "Monika" && p.Sender.Surname == "Jankowska"),
                    PackageID = Packages.Single(p => p.Sender.Name == "Monika" && p.Sender.Surname == "Jankowska").ID,
                    SenderPostOffice = postOffices.Single(po => po.Address.Street == "Gdańska"),
                    SenderPostOfficeID = postOffices.Single(po => po.Address.Street == "Gdańska").PostOfficeID,
                    ReceiverPostOffice = postOffices.Single(po => po.Address.Street == "Krakowskie Przedmieście"),
                    ReceiverPostOfficeID = postOffices.Single(po => po.Address.Street == "Krakowskie Przedmieście").PostOfficeID,
                    Status = statuses.Single(s => s.Name == "Ordered"),
                    StatusID = statuses.Single(s => s.Name == "Ordered").StatusID },

                new Delivery {
                    CreatedDate = DateTime.Parse("2024-08-24 13:00:00"),
                    ExpectedDeliveryDate = DateTime.Parse("2024-08-27 20:00:00"),
                    StatusUpdateDate = DateTime.Parse("2024-08-24 13:15:00"),
                    Package = Packages.Single(p => p.Sender.Name == "Marek" && p.Sender.Surname == "Szymański"),
                    PackageID = Packages.Single(p => p.Sender.Name == "Marek" && p.Sender.Surname == "Szymański").ID,
                    SenderPostOffice = postOffices.Single(po => po.Address.Street == "Święty Marcin"),
                    SenderPostOfficeID = postOffices.Single(po => po.Address.Street == "Święty Marcin").PostOfficeID,
                    ReceiverPostOffice = postOffices.Single(po => po.Address.Street == "Lipowa"),
                    ReceiverPostOfficeID = postOffices.Single(po => po.Address.Street == "Lipowa").PostOfficeID,
                    Status = statuses.Single(s => s.Name == "Returned"),
                    StatusID = statuses.Single(s => s.Name == "Returned").StatusID },

                new Delivery {
                    CreatedDate = DateTime.Parse("2024-08-26 07:30:00"),
                    ExpectedDeliveryDate = DateTime.Parse("2024-08-29 14:00:00"),
                    StatusUpdateDate = DateTime.Parse("2024-08-26 07:45:00"),
                    Package = Packages.Single(p => p.Sender.Name == "Agnieszka" && p.Sender.Surname == "Wróbel"),
                    PackageID = Packages.Single(p => p.Sender.Name == "Agnieszka" && p.Sender.Surname == "Wróbel").ID,
                    SenderPostOffice = postOffices.Single(po => po.Address.Street == "Gdańska"),
                    SenderPostOfficeID = postOffices.Single(po => po.Address.Street == "Gdańska").PostOfficeID,
                    ReceiverPostOffice = postOffices.Single(po => po.Address.Street == "Jagiellońska"),
                    ReceiverPostOfficeID = postOffices.Single(po => po.Address.Street == "Jagiellońska").PostOfficeID,
                    Status = statuses.Single(s => s.Name == "In Transit"),
                    StatusID = statuses.Single(s => s.Name == "In Transit").StatusID },

                new Delivery {
                    CreatedDate = DateTime.Parse("2024-08-27 16:20:00"),
                    ExpectedDeliveryDate = DateTime.Parse("2024-08-30 11:00:00"),
                    StatusUpdateDate = DateTime.Parse("2024-08-27 16:35:00"),
                    Package = Packages.Single(p => p.Sender.Name == "Łukasz" && p.Sender.Surname == "Michalski"),
                    PackageID = Packages.Single(p => p.Sender.Name == "Łukasz" && p.Sender.Surname == "Michalski").ID,
                    SenderPostOffice = postOffices.Single(po => po.Address.Street == "Świętojańska"),
                    SenderPostOfficeID = postOffices.Single(po => po.Address.Street == "Świętojańska").PostOfficeID,
                    ReceiverPostOffice = postOffices.Single(po => po.Address.Street == "Rynek Kościuszki"),
                    ReceiverPostOfficeID = postOffices.Single(po => po.Address.Street == "Rynek Kościuszki").PostOfficeID,
                    Status = statuses.Single(s => s.Name == "Packed"),
                    StatusID = statuses.Single(s => s.Name == "Packed").StatusID },

                new Delivery {
                    CreatedDate = DateTime.Parse("2024-08-23 15:50:00"),
                    ExpectedDeliveryDate = DateTime.Parse("2024-08-26 13:00:00"),
                    StatusUpdateDate = DateTime.Parse("2024-08-23 16:05:00"),
                    Package = Packages.Single(p => p.Sender.Name == "Justyna" && p.Sender.Surname == "Krawczyk"),
                    PackageID = Packages.Single(p => p.Sender.Name == "Justyna" && p.Sender.Surname == "Krawczyk").ID,
                    SenderPostOffice = postOffices.Single(po => po.Address.Street == "Aleja Najświętszej Maryi Panny"),
                    SenderPostOfficeID = postOffices.Single(po => po.Address.Street == "Aleja Najświętszej Maryi Panny").PostOfficeID,
                    ReceiverPostOffice = postOffices.Single(po => po.Address.Street == "Narutowicza"),
                    ReceiverPostOfficeID = postOffices.Single(po => po.Address.Street == "Narutowicza").PostOfficeID,
                    Status = statuses.Single(s => s.Name == "Collected"),
                    StatusID = statuses.Single(s => s.Name == "Collected").StatusID },

                new Delivery {
                    CreatedDate = DateTime.Parse("2024-08-24 18:10:00"),
                    ExpectedDeliveryDate = DateTime.Parse("2024-08-27 10:00:00"),
                    StatusUpdateDate = DateTime.Parse("2024-08-24 18:25:00"),
                    Package = Packages.Single(p => p.Sender.Name == "Rafał" && p.Sender.Surname == "Mazurek"),
                    PackageID = Packages.Single(p => p.Sender.Name == "Rafał" && p.Sender.Surname == "Mazurek").ID,
                    SenderPostOffice = postOffices.Single(po => po.Address.Street == "Piotrkowska"),
                    SenderPostOfficeID = postOffices.Single(po => po.Address.Street == "Piotrkowska").PostOfficeID,
                    ReceiverPostOffice = postOffices.Single(po => po.Address.Street == "Mariacka"),
                    ReceiverPostOfficeID = postOffices.Single(po => po.Address.Street == "Mariacka").PostOfficeID,
                    Status = statuses.Single(s => s.Name == "Ordered"),
                    StatusID = statuses.Single(s => s.Name == "Ordered").StatusID },

                new Delivery {
                    CreatedDate = DateTime.Parse("2024-08-25 08:00:00"),
                    ExpectedDeliveryDate = DateTime.Parse("2024-08-28 09:00:00"),
                    StatusUpdateDate = DateTime.Parse("2024-08-25 08:15:00"),
                    Package = Packages.Single(p => p.Sender.Name == "Zofia" && p.Sender.Surname == "Kalinowska"),
                    PackageID = Packages.Single(p => p.Sender.Name == "Zofia" && p.Sender.Surname == "Kalinowska").ID,
                    SenderPostOffice = postOffices.Single(po => po.Address.Street == "Lipowa"),
                    SenderPostOfficeID = postOffices.Single(po => po.Address.Street == "Lipowa").PostOfficeID,
                    ReceiverPostOffice = postOffices.Single(po => po.Address.Street == "Jasnogórska"),
                    ReceiverPostOfficeID = postOffices.Single(po => po.Address.Street == "Jasnogórska").PostOfficeID,
                    Status = statuses.Single(s => s.Name == "In Transit"),
                    StatusID = statuses.Single(s => s.Name == "In Transit").StatusID }
            };

            foreach (var delivery in deliveries)
            {
                context.Deliveries.Add(delivery);
            }

            context.SaveChanges();
        }
    }
}
