using System;
using System.Collections.Generic;

namespace Smartdrive.Models;

public partial class CustomerInscDoc
{
    public int CadocId { get; set; }

    public int CadocCreqEntityid { get; set; }

    public string? CadocFilename { get; set; }

    public string? CadocFiletype { get; set; }

    public int? CadocFilesize { get; set; }

    public string? CadocCategory { get; set; }

    public DateTime? CadocModifiedDate { get; set; }

    public virtual CustomerInscAsset CadocCreqEntity { get; set; } = null!;
}
