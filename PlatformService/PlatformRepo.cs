
namespace PlatformService;

public class PlatformRepo: IPlatformRepo
{
    private readonly AppDbContext _dbcontext;
    public PlatformRepo(AppDbContext dbcontext)
    {
        _dbcontext = dbcontext;
    }
    public void CreatePlatform(Platform plat)
    {
        _dbcontext.Platforms.Add(plat);
    }

    public IEnumerable<Platform> GetAllPlatforms()
    {
        return _dbcontext.Platforms.ToList();
    }

    public Platform GetPlatformById(int Id)
    {
        return _dbcontext.Platforms.FirstOrDefault(x=>x.Id == Id);
    }

    public bool SaveChanges()
    {
        return _dbcontext.SaveChanges()>0;
    }
}
