namespace Lequ.Models;

public class BlogAlbum : ModelBase
{
	public int BlogID { get; set; }

	public Blog? Blog { get; set; }

	public int AlbumID { get; set; }

	public Album? Album { get; set; }
}