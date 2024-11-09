using System;
using System.Collections.Generic;

namespace FS.DAL.Entities;

public partial class CoppaItaliaPlayer
{
    public string CoppaItaliaPlayerId { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string Position { get; set; } = null!;

    public DateTime? Birthday { get; set; }

    public string InternationalCareer { get; set; } = null!;

    public string StyleOfPlay { get; set; } = null!;

    public string? CoppaItaliaClubId { get; set; }

    public virtual CoppaItaliaClub? CoppaItaliaClub { get; set; }
}
