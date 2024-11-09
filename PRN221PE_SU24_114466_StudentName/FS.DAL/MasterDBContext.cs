using FS.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace FS.DAL;

public class MasterDBContext :DbContext
{
    public MasterDBContext(DbContextOptions<MasterDBContext> options) : base(options)
    {
        
    }

    #region DbSet

    public virtual DbSet<CoppaItaliaAccount> CoppaItaliaAccounts { get; set; }
    public virtual DbSet<CoppaItaliaPlayer> CoppaItaliaPlayerss { get; set; }
    public virtual DbSet<CoppaItaliaClub> CoppaItaliaClubss { get; set; }

    #endregion
}