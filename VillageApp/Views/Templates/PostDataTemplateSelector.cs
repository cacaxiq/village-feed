using VillageApp.Models;

namespace VillageApp.Views.Templates
{
    class PostDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate PostImageTemplate { get; set; }
        public DataTemplate PostImagesTemplate { get; set; }
        public DataTemplate PostTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var post = item as Post;

            if (!post.Medias.Any())
                return PostTemplate;
            else
            {
                if (post.Medias.Count == 1)
                    return PostImageTemplate;
                else
                    return PostImagesTemplate;
            }
        }
    }
}
