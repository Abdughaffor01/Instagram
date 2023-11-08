namespace Infrastructure.Services.FileServices;

public class FileService : IFileService
{
    private readonly IWebHostEnvironment _environment;
    public FileService(IWebHostEnvironment environment) => _environment = environment;

    public async Task<string> AddFileAsync(IFormFile file, string folder)
    {
        try
        {
            string folderpath = Path.Combine(_environment.WebRootPath, folder);
            string filename = Guid.NewGuid() + Path.GetExtension(file.FileName);
            if (Directory.Exists(folderpath) == false) Directory.CreateDirectory(folderpath);
            string fullpath = Path.Combine(folderpath, filename);
            using var stream = new FileStream(fullpath, FileMode.OpenOrCreate);
            await file.CopyToAsync(stream);
            return filename;
        }
        catch (Exception)
        {
            return "";
        }
    }

    public async Task<bool> DeleteFileAsync(string filename, string folder)
    {
        try
        {
            return await Task.Run(() =>
            {
                string fullpath = Path.Combine(_environment.WebRootPath, folder, filename);
                File.Delete(fullpath);
                return true;
            });
        }
        catch (Exception)
        {
            return false;
        }
    }
}