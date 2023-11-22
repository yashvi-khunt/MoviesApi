﻿using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Validations
{
    public class ContentTypeValidator : ValidationAttribute
    {
        private readonly string[] validContentTypes;
        private readonly string[] imageContentTypes = new string[] { "image/jpeg", "image/png", "image/gif","image/jpg" };

        public ContentTypeValidator(string[] ValidContentTypes)
        {
            validContentTypes = ValidContentTypes;
        }

        public ContentTypeValidator(ContentTypeGroup contentTypeGroup)
        {
            switch (contentTypeGroup)
            {
                case ContentTypeGroup.Image:
                    validContentTypes = imageContentTypes;
                    break;
            }
        }


        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            IFormFile formFile = value as IFormFile;

            if (formFile == null)
            {
                return ValidationResult.Success;
            }

            if (!validContentTypes.Contains(formFile.ContentType))
            {
                return new ValidationResult($"Content-Type should be one of the following: {string.Join(", ", validContentTypes)}");
            }

            return ValidationResult.Success;
        }

        public enum ContentTypeGroup
        {
            Image
        }
    }
}