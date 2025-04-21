using Music.Models;
using Music.Services;
using static Music.Enum.EnumGenre;

var songService = new SongService();
var playlistService = new PlaylistService();

while (true)
{
    Console.WriteLine("\n--- MUSIC APP ---");
    Console.WriteLine("1. Mahnı əlavə et");
    Console.WriteLine("2. Playlist yarat");
    Console.WriteLine("3. Bütün mahnılara bax");
    Console.WriteLine("4. Playlist-ə mahnı əlavə et");
    Console.WriteLine("5. Playlist-lərə bax");
    Console.WriteLine("6. Playlist-də mahnı axtar");
    Console.WriteLine("0. Çıx");
    Console.Write("Seçiminiz: ");
    var choice = Console.ReadLine();

    try
    {
        switch (choice)
        {
            case "1":
                Console.Write("Mahnı adı: ");
                var name = Console.ReadLine();
                Console.Write("Artist(, ilə ayırın): ");
                var artists = Console.ReadLine().Split(',').Select(a => a.Trim()).ToList();
                Console.Write("Janr (Pop, Rock, Jazz, HipHop, Classical, Electronic): ");
                var genre = (GenreEnum)Enum.Parse(typeof(GenreEnum), Console.ReadLine(), true);
                Console.Write("Uzunluq (saniyə ilə): ");
                var duration = int.Parse(Console.ReadLine());

                songService.Create(new Song
                {
                    SongName = name,
                    ArtistNames = artists,
                    Genre = genre,
                    Duration = duration
                });
                Console.WriteLine("Mahnı əlavə olundu.");
                break;

            case "2":
                Console.Write("Playlist adı: ");
                var pname = Console.ReadLine();
                playlistService.Create(new Playlist { PlaylistName = pname });
                Console.WriteLine("Playlist yaradıldı.");
                break;

            case "3":
                foreach (var s in songService.GetAll())
                {
                    Console.WriteLine($"[{s.Id}] {s.SongName} - {string.Join(", ", s.ArtistNames)} ({s.Genre})");
                }
                break;

            case "4":
                Console.Write("Playlist ID: ");
                var pid = int.Parse(Console.ReadLine());
                Console.Write("Mahnı ID: ");
                var sid = int.Parse(Console.ReadLine());

                var playlist = playlistService.GetById(pid);
                var song = songService.GetById(sid);
                playlist.Songs.Add(song);
                Console.WriteLine("Mahnı playlistə əlavə olundu.");
                break;

            case "5":
                foreach (var pl in playlistService.GetAll())
                {
                    Console.WriteLine($"\n[{pl.Id}] {pl.PlaylistName}");
                    foreach (var s in pl.Songs)
                        Console.WriteLine($"   - {s.SongName}");
                }
                break;

            case "6":
                Console.Write("Playlist ID: ");
                var plId = int.Parse(Console.ReadLine());
                Console.Write("Artist adı (boş buraxmaq olar): ");
                var aName = Console.ReadLine();
                Console.Write("Mahnı adı (boş buraxmaq olar): ");
                var mName = Console.ReadLine();
                Console.Write("Janr (boş buraxmaq olar): ");
                var jName = Console.ReadLine();

                var filtered = playlistService.FilterSongs(plId, aName, mName, jName);
                foreach (var f in filtered)
                    Console.WriteLine($"{f.SongName} - {string.Join(", ", f.ArtistNames)} ({f.Genre})");
                break;

            case "0":
                return;

            default:
                Console.WriteLine("Yanlış seçim.");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Xəta baş verdi: {ex.Message}");
    }
}
