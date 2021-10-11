namespace TaskTracker.Application.Common.Helpers
{
    public class TextHelper
    {
        public static string Existing(string value) => $"{value} already exists";

        public static string Created(string value) => $"{value} has been created successfully";

        public static string Deleted(string value) => $"{value} has been deleted successfully";

        public static string Updated(string value) => $"{value} has been updated successfully";

        public static string CouldNotCreated(string value) => $"{value} could not created";

        public static string CouldNotUpdated(string value) => $"{value} could not updated";

        public static string ErrorDeleting(string value) => $"Error deleting {value}";
    }
}
