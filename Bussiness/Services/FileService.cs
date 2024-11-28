using Bussiness.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;

namespace Bussiness.Services;

public class FileService
{
    private readonly string _dircetoryPath;
    private readonly string _filePath;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    // The constructor takes two optional parameters: directoryPath and fileName.
    public FileService(string directoryPath = "Data", string fileName = "list.json")
    {
        //Constructor
        // Combine the directory path and file name to create the full file path.
        _dircetoryPath = directoryPath;
        _filePath = fileName;
        _filePath = Path.Combine(_dircetoryPath, _filePath);
        // Set the options to write indented JSON. WriteIndented lists the JSON objects in a more readable format.
        _jsonSerializerOptions = new JsonSerializerOptions { WriteIndented = true };
    }

    public void SaveListToFile(List<UserModel> list)
    {
        try
        {
            // Check if the directory exists. If it doesn't, create it.
            if (!Directory.Exists(_dircetoryPath))
            {
                Directory.CreateDirectory(_dircetoryPath);
            }
            // Serialize the list to JSON and write it to the file.
            var json = JsonSerializer.Serialize(list, _jsonSerializerOptions);
            File.WriteAllText(_filePath, json);
        }
        catch (Exception ex)
        {
            // Log the error message to the Debug window.
            Debug.WriteLine($"An error occurred while saving the file: {ex.Message}");
        }
    }

    public List<UserModel> LoadListFromFile() 
    {
        try
        {
            // Check if the file exists. If it doesn't, return an empty list.
            if (!File.Exists(_filePath))
            {
                return new List<UserModel>();
            }
            var json = File.ReadAllText(_filePath);
            var list = JsonSerializer.Deserialize<List<UserModel>>(json, _jsonSerializerOptions);
            // Return the list if it's not null, otherwise return an empty list.
            return list ?? new List<UserModel>();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"An error occurred while loading the file: {ex.Message}");
            return [];
        }
    }
}
