using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SGSWS.Model;

public partial class _ContextR : DbContext
{
    public _ContextR()
    {
    }

    public _ContextR(DbContextOptions<_ContextR> options)
        : base(options)
    {
    }

    public virtual DbSet<Alusert> Aluserts { get; set; }

    public virtual DbSet<EbPrfmwebv> EbPrfmwebvs { get; set; }

    public virtual DbSet<Knkanbanmegav> Knkanbanmegavs { get; set; }

    public virtual DbSet<Ljjustparskhodrov> Ljjustparskhodrovs { get; set; }

    public virtual DbSet<Ordkashanv> Ordkashanvs { get; set; }

    public virtual DbSet<Txsaipafctv> Txsaipafctvs { get; set; }

    public virtual DbSet<ForeignPurchList> ForeignPurchList { get; set; }

   // public virtual DbSet<StockReceiptDetailList> StockReceiptDetailList { get; set; }



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseOracle("Data Source=10.1.30.12:1521/dbmain.sazehgostar.com; User Id=webservice; Password=salamaleik");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("WEBSERVICE")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<Alusert>(entity =>
        {
            entity.HasKey(e => e.Srl).HasName("ALUSER_PK");

            entity.ToTable("ALUSERT", "ADMIN");

            entity.HasIndex(e => e.Username, "ALUSERT_USERNAME_UK").IsUnique();

            entity.HasIndex(e => e.AluserSrl, "ALUSER_ALUSER_FK_INX");

            entity.HasIndex(e => e.UsrtypSrl, "USR_USRTYP_FK_I");

            entity.Property(e => e.Srl)
                .HasPrecision(6)
                .ValueGeneratedNever()
                .HasColumnName("SRL");
            entity.Property(e => e.AluserSrl)
                .HasPrecision(6)
                .HasColumnName("ALUSER_SRL");
            entity.Property(e => e.ChngDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CHNG_DATE");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.PassBack)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PASS_BACK");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.UDateTime)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("U_DATE_TIME");
            entity.Property(e => e.Userkey)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("USERKEY");
            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("USERNAME");
            entity.Property(e => e.UsrComment)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("USR_COMMENT");
            entity.Property(e => e.UsrtypSrl)
                .HasPrecision(6)
                .HasColumnName("USRTYP_SRL");

            entity.HasOne(d => d.AluserSrlNavigation).WithMany(p => p.InverseAluserSrlNavigation)
                .HasForeignKey(d => d.AluserSrl)
                .HasConstraintName("ALUSER_ALUSER_FK");
        });

        modelBuilder.Entity<EbPrfmwebv>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("EB_PRFMWEBV", "ADMIN");

            entity.Property(e => e.AgriQty)
                .HasColumnType("NUMBER(15,3)")
                .HasColumnName("AGRI_QTY");
            entity.Property(e => e.AgriSeq)
                .HasPrecision(6)
                .HasColumnName("AGRI_SEQ");
            entity.Property(e => e.AgrmDate)
                .HasMaxLength(46)
                .IsUnicode(false)
                .HasColumnName("AGRM_DATE");
            entity.Property(e => e.AgrmNum)
                .HasPrecision(12)
                .HasColumnName("AGRM_NUM");
            entity.Property(e => e.AgrmTasvibDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("AGRM_TASVIB_DATE");
            entity.Property(e => e.BiprtcSrl)
                .HasPrecision(6)
                .HasColumnName("BIPRTC_SRL");
            entity.Property(e => e.BrandCode)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("BRAND_CODE");
            entity.Property(e => e.BrandName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("BRAND_NAME");
            entity.Property(e => e.CgitmmSrl)
                .HasPrecision(6)
                .HasColumnName("CGITMM_SRL");
            entity.Property(e => e.ComplName)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("COMPL_NAME");
            entity.Property(e => e.ConsumeRate)
                .HasColumnType("NUMBER")
                .HasColumnName("CONSUME_RATE");
            entity.Property(e => e.CountryCode)
                .HasPrecision(4)
                .HasColumnName("COUNTRY_CODE");
            entity.Property(e => e.CountrySalCode)
                .HasPrecision(4)
                .HasColumnName("COUNTRY_SAL_CODE");
            entity.Property(e => e.CountrySalTitle)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("COUNTRY_SAL_TITLE");
            entity.Property(e => e.CountryTitle)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("COUNTRY_TITLE");
            entity.Property(e => e.FirstPayDt)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("FIRST_PAY_DT");
            entity.Property(e => e.GrouhKala)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("GROUH_KALA");
            entity.Property(e => e.ItmCod)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("ITM_COD");
            entity.Property(e => e.MandePrfm)
                .HasColumnType("NUMBER")
                .HasColumnName("MANDE_PRFM");
            entity.Property(e => e.MandehDar)
                .HasColumnType("NUMBER")
                .HasColumnName("MANDEH_DAR");
            entity.Property(e => e.Nobat)
                .HasColumnType("NUMBER")
                .HasColumnName("NOBAT");
            entity.Property(e => e.OrdDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ORD_DATE");
            entity.Property(e => e.OrdNum)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("ORD_NUM");
            entity.Property(e => e.OrdQty)
                .HasColumnType("NUMBER(15,3)")
                .HasColumnName("ORD_QTY");
            entity.Property(e => e.OrdRecNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ORD_REC_NO");
            entity.Property(e => e.PerTa)
                .HasColumnType("NUMBER")
                .HasColumnName("PER_TA");
            entity.Property(e => e.PrfmDate)
                .HasColumnType("DATE")
                .HasColumnName("PRFM_DATE");
            entity.Property(e => e.PrfmManuCode)
                .HasPrecision(6)
                .HasColumnName("PRFM_MANU_CODE");
            entity.Property(e => e.PrfmManuName)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("PRFM_MANU_NAME");
            entity.Property(e => e.PrfmQty)
                .HasColumnType("NUMBER(16,4)")
                .HasColumnName("PRFM_QTY");
            entity.Property(e => e.PrfmShamsiDte)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PRFM_SHAMSI_DTE");
            entity.Property(e => e.PrfmiIssCode)
                .HasPrecision(6)
                .HasColumnName("PRFMI_ISS_CODE");
            entity.Property(e => e.PrfmiIssName)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("PRFMI_ISS_NAME");
            entity.Property(e => e.Prfmno)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("PRFMNO");
            entity.Property(e => e.PrtNum)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PRT_NUM");
            entity.Property(e => e.PrtNumHead)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PRT_NUM_HEAD");
            entity.Property(e => e.PrtTitleF)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("PRT_TITLE_F");
            entity.Property(e => e.PumonytCode)
                .HasPrecision(4)
                .HasColumnName("PUMONYT_CODE");
            entity.Property(e => e.PumonytTitle)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PUMONYT_TITLE");
            entity.Property(e => e.ReciveDate)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("RECIVE_DATE");
            entity.Property(e => e.ResidDte)
                .HasMaxLength(46)
                .IsUnicode(false)
                .HasColumnName("RESID_DTE");
            entity.Property(e => e.ResidQty)
                .HasColumnType("NUMBER")
                .HasColumnName("RESID_QTY");
            entity.Property(e => e.Rqty)
                .HasColumnType("NUMBER")
                .HasColumnName("RQTY");
            entity.Property(e => e.TrkdQty)
                .HasColumnType("NUMBER")
                .HasColumnName("TRKD_QTY");
            entity.Property(e => e.UnitPrice)
                .HasColumnType("NUMBER(22,6)")
                .HasColumnName("UNIT_PRICE");
            entity.Property(e => e.UnitTitle)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("UNIT_TITLE");
        });

        modelBuilder.Entity<Knkanbanmegav>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("KNKANBANMEGAV", "ADMIN");

            entity.Property(e => e.ItmCod)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ITM_COD");
            entity.Property(e => e.KanbanDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("KANBAN_DATE");
            entity.Property(e => e.KanbanNo)
                .HasColumnType("NUMBER(20)")
                .HasColumnName("KANBAN_NO");
            entity.Property(e => e.KnkanbanSrl)
                .HasPrecision(12)
                .HasColumnName("KNKANBAN_SRL");
            entity.Property(e => e.NdcdldSrl)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("NDCDLD_SRL");
            entity.Property(e => e.PrtNum)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PRT_NUM");
            entity.Property(e => e.PubrndSrl)
                .HasPrecision(6)
                .HasColumnName("PUBRND_SRL");
            entity.Property(e => e.Qty)
                .HasPrecision(12)
                .HasColumnName("QTY");
        });

        modelBuilder.Entity<Ljjustparskhodrov>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("LJJUSTPARSKHODROV", "ADMIN");

            entity.Property(e => e.AdaptionDt)
                .HasMaxLength(46)
                .IsUnicode(false)
                .HasColumnName("ADAPTION_DT");
            entity.Property(e => e.BodySrl)
                .HasColumnType("NUMBER")
                .HasColumnName("BODY_SRL");
            entity.Property(e => e.BonroPlace)
                .HasColumnType("NUMBER")
                .HasColumnName("BONRO_PLACE");
            entity.Property(e => e.CarSrl)
                .HasColumnType("NUMBER")
                .HasColumnName("CAR_SRL");
            entity.Property(e => e.ConstructorSrl)
                .HasPrecision(6)
                .HasColumnName("CONSTRUCTOR_SRL");
            entity.Property(e => e.ItemCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ITEM_CODE");
            entity.Property(e => e.LicenseReason)
                .HasMaxLength(600)
                .IsUnicode(false)
                .HasColumnName("LICENSE_REASON");
            entity.Property(e => e.NoAdaptDesc)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("NO_ADAPT_DESC");
            entity.Property(e => e.ParskhodroPlace)
                .HasColumnType("NUMBER")
                .HasColumnName("PARSKHODRO_PLACE");
            entity.Property(e => e.PartNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PART_NO");
            entity.Property(e => e.Qty)
                .HasPrecision(12)
                .HasColumnName("QTY");
            entity.Property(e => e.SaipaPlace)
                .HasColumnType("NUMBER")
                .HasColumnName("SAIPA_PLACE");
            entity.Property(e => e.SaipakashanPlace)
                .HasColumnType("NUMBER")
                .HasColumnName("SAIPAKASHAN_PLACE");
            entity.Property(e => e.SaipayadakPlace)
                .HasColumnType("NUMBER")
                .HasColumnName("SAIPAYADAK_PLACE");
            entity.Property(e => e.SendPlanDt)
                .HasMaxLength(46)
                .IsUnicode(false)
                .HasColumnName("SEND_PLAN_DT");
            entity.Property(e => e.Srl)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SRL");
            entity.Property(e => e.SubConstructorSrl)
                .HasPrecision(6)
                .HasColumnName("SUB_CONSTRUCTOR_SRL");
            entity.Property(e => e.TaminGroup)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("TAMIN_GROUP");
            entity.Property(e => e.TaminMojavezNo)
                .HasPrecision(8)
                .HasColumnName("TAMIN_MOJAVEZ_NO");
            entity.Property(e => e.UDateTime)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("U_DATE_TIME");
        });

        modelBuilder.Entity<Ordkashanv>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ORDKASHANV", "ADMIN");

            entity.Property(e => e.ItmCod)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("ITM_COD");
            entity.Property(e => e.OrRem)
                .HasColumnType("NUMBER")
                .HasColumnName("OR_REM");
            entity.Property(e => e.OrdDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ORD_DATE");
            entity.Property(e => e.OrdNum)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("ORD_NUM");
            entity.Property(e => e.PrtNum)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PRT_NUM");
            entity.Property(e => e.Qty)
                .HasColumnType("NUMBER(15,3)")
                .HasColumnName("QTY");
        });

        modelBuilder.Entity<Txsaipafctv>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("TXSAIPAFCTV", "ADMIN");

            entity.Property(e => e.CsmconSrl)
                .HasPrecision(6)
                .HasColumnName("CSMCON_SRL");
            entity.Property(e => e.CustItmCode)
                .IsUnicode(false)
                .HasColumnName("CUST_ITM_CODE");
            entity.Property(e => e.CustResidDate)
                .IsUnicode(false)
                .HasColumnName("CUST_RESID_DATE");
            entity.Property(e => e.CustResidNo)
                .IsUnicode(false)
                .HasColumnName("CUST_RESID_NO");
            entity.Property(e => e.CustResidNoOthers)
                .IsUnicode(false)
                .HasColumnName("CUST_RESID_NO_OTHERS");
            entity.Property(e => e.FactType)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("FACT_TYPE");
            entity.Property(e => e.Fee)
                .HasColumnType("NUMBER")
                .HasColumnName("FEE");
            entity.Property(e => e.Irtaxid)
                .HasMaxLength(22)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("IRTAXID");
            entity.Property(e => e.ItmPrice)
                .HasColumnType("NUMBER(20,3)")
                .HasColumnName("ITM_PRICE");
            entity.Property(e => e.ManuCode)
                .HasPrecision(6)
                .HasColumnName("MANU_CODE");
            entity.Property(e => e.ManuName)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("MANU_NAME");
            entity.Property(e => e.PrtNum)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PRT_NUM");
            entity.Property(e => e.Qty)
                .HasColumnType("NUMBER(28,8)")
                .HasColumnName("QTY");
            entity.Property(e => e.SgsAsnNum)
                .IsUnicode(false)
                .HasColumnName("SGS_ASN_NUM");
            entity.Property(e => e.SgsFactDate)
                .HasMaxLength(46)
                .IsUnicode(false)
                .HasColumnName("SGS_FACT_DATE");
            entity.Property(e => e.SgsFactNo)
                .HasPrecision(10)
                .HasColumnName("SGS_FACT_NO");
            entity.Property(e => e.SgsRetaxid)
                .HasMaxLength(22)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SGS_RETAXID");
            entity.Property(e => e.SgsUDateTime)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SGS_U_DATE_TIME");
            entity.Property(e => e.Sstid)
                .HasMaxLength(13)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SSTID");
            entity.Property(e => e.Taxid)
                .HasMaxLength(22)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TAXID");
        });

        modelBuilder.Entity<ForeignPurchList>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("EB_PRFMSAIPAV", "ADMIN");

            entity.Property(e => e.BrndCode)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("BRND_CODE");

            entity.Property(e => e.BrndName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("BRND_NAME");

            entity.Property(e => e.PrtNum)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PRT_NUM");

            entity.Property(e => e.PrtTitle)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("PRT_TITLE");

            entity.Property(e => e.PrfmQty)
                .HasColumnType("NUMBER(16,4)")
                .HasColumnName("PRFM_QTY");

            entity.Property(e => e.PrfmNum)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("PRFM_NUM");

            entity.Property(e => e.PrfmShamsiDte)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PRFM_SHAMSI_DTE");

            entity.Property(e => e.Step)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("STEP");

            entity.Property(e => e.NextStep)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NEXT_STEP");

            entity.Property(e => e.SabteSefareshNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SABTE_SEFARESH_NO");

            entity.Property(e => e.SabteSefareshTitle)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("SABTE_SEFARESH_TITLE");

            entity.Property(e => e.SabteSefareshQty)
                .HasColumnType("NUMBER")
                .HasColumnName("SABTE_SEFARESH_QTY");

            entity.Property(e => e.SabteSefareshDte)
                .HasMaxLength(46)
                .IsUnicode(false)
                .HasColumnName("SABTE_SEFARESH_DTE");

            entity.Property(e => e.EtebarDte)
                .HasMaxLength(4000)
                .IsUnicode(false)
                .HasColumnName("ETEBAR_DTE");

            entity.Property(e => e.TakhssisArzQty)
                .HasColumnType("NUMBER")
                .HasColumnName("TAKHSIS_ARZ_QTY");

            entity.Property(e => e.TakhssisArzDte)
                .HasMaxLength(46)
                .IsUnicode(false)
                .HasColumnName("TAKHSIS_ARZ_DTE");

            entity.Property(e => e.EtebarArzDte)
                .HasMaxLength(4000)
                .IsUnicode(false)
                .HasColumnName("ETEBAR_ARZ_DTE");

            entity.Property(e => e.WaitSwift)
                .HasColumnType("NUMBER")
                .HasColumnName("WAIT_SWIFT");

            entity.Property(e => e.WaitSwiftQty)
                .HasColumnType("NUMBER")
                .HasColumnName("WAIT_SWIFT_QTY");

            entity.Property(e => e.SwiftQty)
                .HasColumnType("NUMBER")
                .HasColumnName("SWIFT_QTY");

            entity.Property(e => e.SwiftDte)
                .HasMaxLength(46)
                .IsUnicode(false)
                .HasColumnName("SWIFT_DTE");

            entity.Property(e => e.HamlQty)
                .HasColumnType("NUMBER")
                .HasColumnName("HAML_QTY");

            entity.Property(e => e.HamlDte)
                .HasMaxLength(4000)
                .IsUnicode(false)
                .HasColumnName("HAML_DTE");

            entity.Property(e => e.GomrokQty)
                .HasColumnType("NUMBER")
                .HasColumnName("GOMROK_QTY");

            entity.Property(e => e.GomrokDte)
                .HasMaxLength(4000)
                .IsUnicode(false)
                .HasColumnName("GOMROK_DTE");

            entity.Property(e => e.TarkhisQty)
                .HasColumnType("NUMBER")
                .HasColumnName("TARKHIS_QTY");

            entity.Property(e => e.TarkhisDte)
                .HasMaxLength(46)
                .IsUnicode(false)
                .HasColumnName("TARKHIS_DTE");

            entity.Property(e => e.ResidQty)
                .HasColumnType("NUMBER")
                .HasColumnName("RESID_QTY");

            entity.Property(e => e.ResidDte)
                .HasMaxLength(46)
                .IsUnicode(false)
                .HasColumnName("RESID_DTE");

            entity.Property(e => e.ForwardDte)
                .HasMaxLength(4000)
                .IsUnicode(false)
                .HasColumnName("FORWARD_DTE");

            entity.Property(e => e.PrfmPrice)
                .HasColumnType("NUMBER(22,6)")
                .HasColumnName("PRFM_PRICE");

            entity.Property(e => e.PumonyDesc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PUMONY_DESC");

            entity.Property(e => e.PrfmTotal)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PRFM_TOTAL");

        });

        modelBuilder.HasSequence("A1", "ADMIN");
        modelBuilder.HasSequence("ALUSRRLLOGT_SEQ", "ADMIN");
        modelBuilder.HasSequence("ALWEBSRV_SEQ", "ADMIN");
        modelBuilder.HasSequence("ASASNS_SEQ", "ADMIN");
        modelBuilder.HasSequence("ASCUSTOMERINV_SEQ", "ADMIN");
        modelBuilder.HasSequence("AUQLD_SEQ", "ADMIN");
        modelBuilder.HasSequence("BACHNG_SEQ", "ADMIN");
        modelBuilder.HasSequence("BEFOOD_SEQ", "ADMIN");
        modelBuilder.HasSequence("BEFREQ_SEQ", "ADMIN");
        modelBuilder.HasSequence("BEMENU_SEQ", "ADMIN");
        modelBuilder.HasSequence("BEPTIM_SEQ", "ADMIN");
        modelBuilder.HasSequence("BEZAMN_SEQ", "ADMIN");
        modelBuilder.HasSequence("BIARCHVPRED_SEQ", "ADMIN");
        modelBuilder.HasSequence("BISAIPASAZEPARTST_SEQ", "ADMIN");
        modelBuilder.HasSequence("CGCIDS_SEQ", "ADMIN");
        modelBuilder.HasSequence("CGFRM_SEQ", "ADMIN");
        modelBuilder.HasSequence("CGITM_SEQ", "ADMIN");
        modelBuilder.HasSequence("CGTAG_SEQ", "ADMIN");
        modelBuilder.HasSequence("CPCOPY_SEQ", "ADMIN");
        modelBuilder.HasSequence("CPINVT_SEQ", "ADMIN");
        modelBuilder.HasSequence("CPMNGS_SEQ", "ADMIN");
        modelBuilder.HasSequence("CPMNGT_SEQ", "ADMIN");
        modelBuilder.HasSequence("CPPLCE_SEQ", "ADMIN");
        modelBuilder.HasSequence("CPRFRN_SEQ", "ADMIN");
        modelBuilder.HasSequence("CPSESS_SEQ", "ADMIN");
        modelBuilder.HasSequence("CPSTYP_SEQ", "ADMIN");
        modelBuilder.HasSequence("CPTASK_CODE", "ADMIN");
        modelBuilder.HasSequence("CPTASK_SEQ", "ADMIN");
        modelBuilder.HasSequence("CT_ATC", "ADMIN");
        modelBuilder.HasSequence("CTCITM_SEQ", "ADMIN");
        modelBuilder.HasSequence("CTCONT_SEQ", "ADMIN");
        modelBuilder.HasSequence("CTDFLOATACH_SEQ", "ADMIN");
        modelBuilder.HasSequence("CTFLPERS_SEQ", "ADMIN");
        modelBuilder.HasSequence("CTMCON_SEQ", "ADMIN");
        modelBuilder.HasSequence("DMLIST_SEQ", "ADMIN");
        modelBuilder.HasSequence("DOCFILE_SEQ", "ADMIN");
        modelBuilder.HasSequence("DODONLOG_SEQ", "ADMIN");
        modelBuilder.HasSequence("EDIFIELD_SEQ", "ADMIN");
        modelBuilder.HasSequence("EDIPARAMETER_SEQ", "ADMIN");
        modelBuilder.HasSequence("EDISERVICE_SEQ", "ADMIN");
        modelBuilder.HasSequence("GABRNCHT_SEQ", "ADMIN");
        modelBuilder.HasSequence("GAISBRNCHT_SEQ", "ADMIN");
        modelBuilder.HasSequence("GASRTD_SEQ", "ADMIN");
        modelBuilder.HasSequence("IBIPIMT_SEQ", "ADMIN");
        modelBuilder.HasSequence("IDADITMASTER_SEQ", "ADMIN");
        modelBuilder.HasSequence("IDC100_SEQ", "ADMIN");
        modelBuilder.HasSequence("IDDOCUMENTDT_SEQ", "ADMIN");
        modelBuilder.HasSequence("IDINFO_SEQ", "ADMIN");
        modelBuilder.HasSequence("IMCONFIRM_SEQ", "ADMIN");
        modelBuilder.HasSequence("IMPRTDUR_SEQ", "ADMIN");
        modelBuilder.HasSequence("IMREASON_SEQ", "ADMIN");
        modelBuilder.HasSequence("IMSTATE_SEQ", "ADMIN");
        modelBuilder.HasSequence("IMSTKREQ_SEQ", "ADMIN");
        modelBuilder.HasSequence("INITINF_SEQ", "ADMIN");
        modelBuilder.HasSequence("INRECALL_SEQ", "ADMIN");
        modelBuilder.HasSequence("INRECALLMOUDL_SEQ", "ADMIN");
        modelBuilder.HasSequence("INRECANS_SEQ", "ADMIN");
        modelBuilder.HasSequence("IPCERT_SEQ", "ADMIN");
        modelBuilder.HasSequence("IPCERT_SEQ_1", "ADMIN");
        modelBuilder.HasSequence("IPENSEND_SEQ", "ADMIN");
        modelBuilder.HasSequence("IPTRTDT_SEQ", "ADMIN");
        modelBuilder.HasSequence("IPTRTHT_SEQ", "ADMIN");
        modelBuilder.HasSequence("ISAGENT_SEQ", "ADMIN");
        modelBuilder.HasSequence("ISBOURS_SEQ", "ADMIN");
        modelBuilder.HasSequence("ISCONT_SEQ", "ADMIN");
        modelBuilder.HasSequence("ISDFAULCUST_SEQ", "ADMIN");
        modelBuilder.HasSequence("ISMODULE_SEQ", "ADMIN");
        modelBuilder.HasSequence("ISPFNL_SEQ", "ADMIN");
        modelBuilder.HasSequence("ISSMCH_SEQ", "ADMIN");
        modelBuilder.HasSequence("ISTELSMS_SEQ", "ADMIN");
        modelBuilder.HasSequence("ITANSW_SEQ", "ADMIN");
        modelBuilder.HasSequence("IXVALD_SEQ", "ADMIN");
        modelBuilder.HasSequence("IXVALT_SEQ", "ADMIN");
        modelBuilder.HasSequence("JUDOCM_SEQ", "ADMIN");
        modelBuilder.HasSequence("KADLPE_SEQ", "ADMIN");
        modelBuilder.HasSequence("KAITM_SEQ", "ADMIN");
        modelBuilder.HasSequence("KAITSG_SEQ", "ADMIN");
        modelBuilder.HasSequence("KASGOG_SEQ", "ADMIN");
        modelBuilder.HasSequence("KBCPRJ_SEQ", "ADMIN");
        modelBuilder.HasSequence("KBFM58_SEQ", "ADMIN");
        modelBuilder.HasSequence("KBRQRJ_SEQ", "ADMIN");
        modelBuilder.HasSequence("KLCLEM_SEQ1", "ADMIN");
        modelBuilder.HasSequence("KLCLEM_SEQ2", "ADMIN");
        modelBuilder.HasSequence("KLCLEM_SEQ3", "ADMIN");
        modelBuilder.HasSequence("KLCLEM_SEQ4", "ADMIN");
        modelBuilder.HasSequence("KLCLEM_SEQ5", "ADMIN");
        modelBuilder.HasSequence("KLCLEM_SEQ6", "ADMIN");
        modelBuilder.HasSequence("KLCLEM_SEQ7", "ADMIN");
        modelBuilder.HasSequence("KLCLEM_SEQ8", "ADMIN");
        modelBuilder.HasSequence("KLMLOGGANT_SEQ", "ADMIN");
        modelBuilder.HasSequence("KLMSTQ_SEQ1", "ADMIN");
        modelBuilder.HasSequence("KLMSTQ_SEQ2", "ADMIN");
        modelBuilder.HasSequence("KLMSTQ_SEQ3", "ADMIN");
        modelBuilder.HasSequence("KLMSTQ_SEQ4", "ADMIN");
        modelBuilder.HasSequence("KLMSTQGANT_SEQ8", "ADMIN");
        modelBuilder.HasSequence("KNADJUST_SEQ", "ADMIN");
        modelBuilder.HasSequence("KNISPERMIT_SEQ", "ADMIN");
        modelBuilder.HasSequence("KNKANBANDET_SEQ", "ADMIN");
        modelBuilder.HasSequence("KNKANBANSET_SEQ", "ADMIN");
        modelBuilder.HasSequence("KNPRTALC_SEQ", "ADMIN");
        modelBuilder.HasSequence("KPBRCD_SEQ", "ADMIN");
        modelBuilder.HasSequence("KPCISB_SEQ", "ADMIN");
        modelBuilder.HasSequence("KPCKDDOC_SEQ", "ADMIN");
        modelBuilder.HasSequence("KPEXSH_SEQ", "ADMIN");
        modelBuilder.HasSequence("KPINVC_SEQ", "ADMIN");
        modelBuilder.HasSequence("KPPREI_SEQ", "ADMIN");
        modelBuilder.HasSequence("KPPREN_SEQ", "ADMIN");
        modelBuilder.HasSequence("KPSHIP_SEQ", "ADMIN");
        modelBuilder.HasSequence("KPSTRN_SEQ", "ADMIN");
        modelBuilder.HasSequence("KSADTM_SEQ", "ADMIN");
        modelBuilder.HasSequence("KZINBOXMSG_SEQ", "ADMIN");
        modelBuilder.HasSequence("LW_ATC", "ADMIN");
        modelBuilder.HasSequence("MH_IPC_SEQ", "ADMIN");
        modelBuilder.HasSequence("MH_IPS_SEQ", "ADMIN");
        modelBuilder.HasSequence("MICROSOFTSEQDTPROPERTIES", "ADMIN");
        modelBuilder.HasSequence("MIORIKS", "ADMIN");
        modelBuilder.HasSequence("MSSPPM1_SEQ", "ADMIN");
        modelBuilder.HasSequence("MSSPPM2_SEQ", "ADMIN");
        modelBuilder.HasSequence("MSSPPM3_SEQ", "ADMIN");
        modelBuilder.HasSequence("MSTPPM1_SEQ", "ADMIN");
        modelBuilder.HasSequence("MSTPPM2_SEQ", "ADMIN");
        modelBuilder.HasSequence("MSTPPM3_SEQ", "ADMIN");
        modelBuilder.HasSequence("MYSEQ", "ADMIN");
        modelBuilder.HasSequence("NDALLOCATE_SEQ", "ADMIN");
        modelBuilder.HasSequence("NDCART_SEQ", "ADMIN");
        modelBuilder.HasSequence("NDCART_SRL_SEQ", "ADMIN");
        modelBuilder.HasSequence("NDCONFIRM_SEQ", "ADMIN");
        modelBuilder.HasSequence("NDCPCS_SEQ", "ADMIN");
        modelBuilder.HasSequence("NDESPATCH_SEQ", "ADMIN");
        modelBuilder.HasSequence("NDFIXD_SEQ", "ADMIN");
        modelBuilder.HasSequence("NDFIXM_SEQ", "ADMIN");
        modelBuilder.HasSequence("NDMPSD_SEQ", "ADMIN");
        modelBuilder.HasSequence("NDMPST_SEQ", "ADMIN");
        modelBuilder.HasSequence("NDMRPREQ_SEQ", "ADMIN");
        modelBuilder.HasSequence("NDPRDLYT_SEQ", "ADMIN");
        modelBuilder.HasSequence("NDR_SEQ", "ADMIN");
        modelBuilder.HasSequence("NDREQYD_ORDNUM_SEQ", "ADMIN");
        modelBuilder.HasSequence("NDTAKHSIS_SEQ", "ADMIN");
        modelBuilder.HasSequence("NDXPCLM_SEQ", "ADMIN");
        modelBuilder.HasSequence("NSWIRELES_SEQ", "ADMIN");
        modelBuilder.HasSequence("ORCCITMT_SEQ", "ADMIN");
        modelBuilder.HasSequence("ORDLOIT_SEQ", "ADMIN");
        modelBuilder.HasSequence("ORDLVO_SEQ", "ADMIN");
        modelBuilder.HasSequence("ORMATERIAL_SEQ", "ADMIN");
        modelBuilder.HasSequence("ORMATIS_SEQ", "ADMIN");
        modelBuilder.HasSequence("ORMATPR_SEQ", "ADMIN");
        modelBuilder.HasSequence("ORORDS_SEQ", "ADMIN");
        modelBuilder.HasSequence("ORORDT_SEQ", "ADMIN");
        modelBuilder.HasSequence("OROTOT_SEQ", "ADMIN");
        modelBuilder.HasSequence("OROTPT_SEQ", "ADMIN");
        modelBuilder.HasSequence("OROTST_SEQ", "ADMIN");
        modelBuilder.HasSequence("ORPERT_SEQ", "ADMIN");
        modelBuilder.HasSequence("ORSTREQ_SEQ", "ADMIN");
        modelBuilder.HasSequence("OSLETER_ARC_SEQ", "ADMIN");
        modelBuilder.HasSequence("OSLETER_MAIN_NUM_SEQ", "ADMIN");
        modelBuilder.HasSequence("OSLETER_NUM_SEQ", "ADMIN");
        modelBuilder.HasSequence("OSLETER_SEQ", "ADMIN");
        modelBuilder.HasSequence("OSLTRLOG_SEQ", "ADMIN");
        modelBuilder.HasSequence("OSLTTRANS_SEQ", "ADMIN");
        modelBuilder.HasSequence("OSPRGRP_SEQ", "ADMIN");
        modelBuilder.HasSequence("OSTRANS_SEQ", "ADMIN");
        modelBuilder.HasSequence("OSTRANSD_SEQ", "ADMIN");
        modelBuilder.HasSequence("PA_PAMRTD_SEQ", "ADMIN");
        modelBuilder.HasSequence("PAANPS_SEQ", "ADMIN");
        modelBuilder.HasSequence("PASMPC_SEQ", "ADMIN");
        modelBuilder.HasSequence("PKPERMIT_SEQ", "ADMIN");
        modelBuilder.HasSequence("PLDECLARE_SEQ", "ADMIN");
        modelBuilder.HasSequence("PLDECLARED_SEQ", "ADMIN");
        modelBuilder.HasSequence("PLPLTMNG_NUM_SEQ", "ADMIN");
        modelBuilder.HasSequence("PLPLTMNG_SEQ", "ADMIN");
        modelBuilder.HasSequence("PLSRSR_SEQ", "ADMIN");
        modelBuilder.HasSequence("PLSTATION_SEQ", "ADMIN");
        modelBuilder.HasSequence("PLUDT_SEQ", "ADMIN");
        modelBuilder.HasSequence("PPM_SEQ", "ADMIN");
        modelBuilder.HasSequence("PRDOCFILE_SEQ", "ADMIN");
        modelBuilder.HasSequence("PREDST_SEQ", "ADMIN");
        modelBuilder.HasSequence("PSACTN_SEQ", "ADMIN");
        modelBuilder.HasSequence("PSPRBD_SEQ", "ADMIN");
        modelBuilder.HasSequence("PSPRBM_SEQ", "ADMIN");
        modelBuilder.HasSequence("PSSNDH_REF_SEQ", "ADMIN");
        modelBuilder.HasSequence("PSSNDH_SEQ", "ADMIN");
        modelBuilder.HasSequence("PSVREQ_SEQ", "ADMIN");
        modelBuilder.HasSequence("RPPM_SEQ", "ADMIN");
        modelBuilder.HasSequence("SAADJM_SEQ", "ADMIN");
        modelBuilder.HasSequence("SAFCTM_SEQ", "ADMIN");
        modelBuilder.HasSequence("SBBANK_SEQ", "ADMIN");
        modelBuilder.HasSequence("SBDOC_SEQ", "ADMIN");
        modelBuilder.HasSequence("SBDOCD_SEQ", "ADMIN");
        modelBuilder.HasSequence("SBGHES_SEQ", "ADMIN");
        modelBuilder.HasSequence("SBMOIN_SEQ", "ADMIN");
        modelBuilder.HasSequence("SBTAFZIL_SEQ", "ADMIN");
        modelBuilder.HasSequence("SBVOSOLD_SEQ", "ADMIN");
        modelBuilder.HasSequence("SBVOSOLH_SEQ", "ADMIN");
        modelBuilder.HasSequence("SEQ_8", "ADMIN");
        modelBuilder.HasSequence("SGTOOLT_SEQ1", "ADMIN");
        modelBuilder.HasSequence("SGTOOLT_SEQ10", "ADMIN");
        modelBuilder.HasSequence("SGTOOLT_SEQ11", "ADMIN");
        modelBuilder.HasSequence("SGTOOLT_SEQ12", "ADMIN");
        modelBuilder.HasSequence("SGTOOLT_SEQ13", "ADMIN");
        modelBuilder.HasSequence("SGTOOLT_SEQ14", "ADMIN");
        modelBuilder.HasSequence("SGTOOLT_SEQ15", "ADMIN");
        modelBuilder.HasSequence("SGTOOLT_SEQ16", "ADMIN");
        modelBuilder.HasSequence("SGTOOLT_SEQ17", "ADMIN");
        modelBuilder.HasSequence("SGTOOLT_SEQ18", "ADMIN");
        modelBuilder.HasSequence("SGTOOLT_SEQ19", "ADMIN");
        modelBuilder.HasSequence("SGTOOLT_SEQ2", "ADMIN");
        modelBuilder.HasSequence("SGTOOLT_SEQ20", "ADMIN");
        modelBuilder.HasSequence("SGTOOLT_SEQ21", "ADMIN");
        modelBuilder.HasSequence("SGTOOLT_SEQ22", "ADMIN");
        modelBuilder.HasSequence("SGTOOLT_SEQ23", "ADMIN");
        modelBuilder.HasSequence("SGTOOLT_SEQ24", "ADMIN");
        modelBuilder.HasSequence("SGTOOLT_SEQ25", "ADMIN");
        modelBuilder.HasSequence("SGTOOLT_SEQ26", "ADMIN");
        modelBuilder.HasSequence("SGTOOLT_SEQ27", "ADMIN");
        modelBuilder.HasSequence("SGTOOLT_SEQ29", "ADMIN");
        modelBuilder.HasSequence("SGTOOLT_SEQ3", "ADMIN");
        modelBuilder.HasSequence("SGTOOLT_SEQ30", "ADMIN");
        modelBuilder.HasSequence("SGTOOLT_SEQ4", "ADMIN");
        modelBuilder.HasSequence("SGTOOLT_SEQ40", "ADMIN");
        modelBuilder.HasSequence("SGTOOLT_SEQ41", "ADMIN");
        modelBuilder.HasSequence("SGTOOLT_SEQ43", "ADMIN");
        modelBuilder.HasSequence("SGTOOLT_SEQ44", "ADMIN");
        modelBuilder.HasSequence("SGTOOLT_SEQ5", "ADMIN");
        modelBuilder.HasSequence("SGTOOLT_SEQ6", "ADMIN");
        modelBuilder.HasSequence("SGTOOLT_SEQ7", "ADMIN");
        modelBuilder.HasSequence("SGTOOLT_SEQ8", "ADMIN");
        modelBuilder.HasSequence("SGTOOLT_SEQ9", "ADMIN");
        modelBuilder.HasSequence("SHGUILTY_SEQ", "ADMIN");
        modelBuilder.HasSequence("SHINVENTSTK_SEQ", "ADMIN");
        modelBuilder.HasSequence("SHLACKT_SEQ", "ADMIN");
        modelBuilder.HasSequence("SHLACKT_SEQ1", "ADMIN");
        modelBuilder.HasSequence("SHLNST_SEQ", "ADMIN");
        modelBuilder.HasSequence("SHMDCS_SEQ", "ADMIN");
        modelBuilder.HasSequence("SHMDYD_SEQ", "ADMIN");
        modelBuilder.HasSequence("SHMDYT_SEQ", "ADMIN");
        modelBuilder.HasSequence("SHPLNB_SEQ", "ADMIN");
        modelBuilder.HasSequence("SHPLNT_SEQ", "ADMIN");
        modelBuilder.HasSequence("SHPRCT_SEQ", "ADMIN");
        modelBuilder.HasSequence("SHPRST_SEQ", "ADMIN");
        modelBuilder.HasSequence("SHSAIPAPROD_SEQ", "ADMIN");
        modelBuilder.HasSequence("SRBARCODE_SEQ", "ADMIN");
        modelBuilder.HasSequence("SRBLRD_SEQ", "ADMIN");
        modelBuilder.HasSequence("SRBRCD_SEQ", "ADMIN");
        modelBuilder.HasSequence("SRCENC_SEQ", "ADMIN");
        modelBuilder.HasSequence("SRCENCSDT_SEQ", "ADMIN");
        modelBuilder.HasSequence("SRCENCST_SEQ", "ADMIN");
        modelBuilder.HasSequence("SRCEND_SEQ", "ADMIN");
        modelBuilder.HasSequence("SRCISU_SEQ", "ADMIN");
        modelBuilder.HasSequence("SRCOIL_SEQ", "ADMIN");
        modelBuilder.HasSequence("SRCOLLSHIP_SEQ", "ADMIN");
        modelBuilder.HasSequence("SRCTMD_SEQ", "ADMIN");
        modelBuilder.HasSequence("SRCURV_SEQ", "ADMIN");
        modelBuilder.HasSequence("SRF40H_KN_SEQ", "ADMIN");
        modelBuilder.HasSequence("SRF40H_KN_SEQ2", "ADMIN");
        modelBuilder.HasSequence("SRF40H_RES", "ADMIN");
        modelBuilder.HasSequence("SRF40H_SEQ", "ADMIN");
        modelBuilder.HasSequence("SRF40H_SEQ_1", "ADMIN");
        modelBuilder.HasSequence("SRF40H_SEQ_2", "ADMIN");
        modelBuilder.HasSequence("SRF40H_SEQ_3", "ADMIN");
        modelBuilder.HasSequence("SRF40H_SEQ_4", "ADMIN");
        modelBuilder.HasSequence("SRF40H_SEQ_5", "ADMIN");
        modelBuilder.HasSequence("SRF40H_SEQ_EMERSUN", "ADMIN");
        modelBuilder.HasSequence("SRF40H_SEQ_ETEHAD", "ADMIN");
        modelBuilder.HasSequence("SRF40H_SEQ_SANDEN", "ADMIN");
        modelBuilder.HasSequence("SRF40H_SEQ_SETCO", "ADMIN");
        modelBuilder.HasSequence("SRF40H_SEQ_SYADAK", "ADMIN");
        modelBuilder.HasSequence("SRF40H_SEQ_SYADAK2", "ADMIN");
        modelBuilder.HasSequence("SRF40H_SEQ_TRUCKTOR", "ADMIN");
        modelBuilder.HasSequence("SRF40H_SEQ_VAGON", "ADMIN");
        modelBuilder.HasSequence("SRF40L_SEQ", "ADMIN");
        modelBuilder.HasSequence("SRF42H_SEQ", "ADMIN");
        modelBuilder.HasSequence("SRFM40_SEQ", "ADMIN");
        modelBuilder.HasSequence("SRFM42_SEQ", "ADMIN");
        modelBuilder.HasSequence("SRFM57_SEQ", "ADMIN");
        modelBuilder.HasSequence("SRFOOLAD_SEQ", "ADMIN");
        modelBuilder.HasSequence("SRFOOLADGRN_SEQ", "ADMIN");
        modelBuilder.HasSequence("SRMW40_SEQ", "ADMIN");
        modelBuilder.HasSequence("SRMWDT_SEQ", "ADMIN");
        modelBuilder.HasSequence("SRMWLOG_SEQ", "ADMIN");
        modelBuilder.HasSequence("SRMWSAIPA_SEQ", "ADMIN");
        modelBuilder.HasSequence("SRODL_SEQ", "ADMIN");
        modelBuilder.HasSequence("SRRPTD_TESTREPORT_SEQ", "ADMIN");
        modelBuilder.HasSequence("SRRPTH_SEQ", "ADMIN");
        modelBuilder.HasSequence("SRRPTH_SEQ1", "ADMIN");
        modelBuilder.HasSequence("SRSERIAL_SEQ", "ADMIN");
        modelBuilder.HasSequence("SRSHIPCTRL_SEQ", "ADMIN");
        modelBuilder.HasSequence("SRSHIPMENTNUM_SEQ", "ADMIN");
        modelBuilder.HasSequence("SRZAMYADASN_SEQ", "ADMIN");
        modelBuilder.HasSequence("SSAGND_SEQ", "ADMIN");
        modelBuilder.HasSequence("SSAGNH_SEQ", "ADMIN");
        modelBuilder.HasSequence("SSAGNI_SEQ", "ADMIN");
        modelBuilder.HasSequence("SSAGNT_SEQ", "ADMIN");
        modelBuilder.HasSequence("SSBIGPR_SEQ", "ADMIN");
        modelBuilder.HasSequence("STADJM_SEQ", "ADMIN");
        modelBuilder.HasSequence("STCTEXTRA_SEQ", "ADMIN");
        modelBuilder.HasSequence("SUINDEXMON_SEQ", "ADMIN");
        modelBuilder.HasSequence("SUSEQ", "ADMIN");
        modelBuilder.HasSequence("TCATHRZ_SEQ", "ADMIN");
        modelBuilder.HasSequence("TMECNCOUST_SEQ", "ADMIN");
        modelBuilder.HasSequence("TMEMKAN_SEQ", "ADMIN");
        modelBuilder.HasSequence("TMREQDOCBIT_SEQ", "ADMIN");
        modelBuilder.HasSequence("TMREQDOCDT_SEQ", "ADMIN");
        modelBuilder.HasSequence("TMREQDOCT_SEQ", "ADMIN");
        modelBuilder.HasSequence("TSCART_SEQ", "ADMIN");
        modelBuilder.HasSequence("TTBASE_SEQ", "ADMIN");
        modelBuilder.HasSequence("TTBASED_SEQ", "ADMIN");
        modelBuilder.HasSequence("TTRACE_SEQ", "ADMIN");
        modelBuilder.HasSequence("TTRACED_SEQ", "ADMIN");
        modelBuilder.HasSequence("TTRACESHIP_SEQ", "ADMIN");
        modelBuilder.HasSequence("TXFCTM_INNO_SEQ", "ADMIN");
        modelBuilder.HasSequence("UAPASS_SEQ", "ADMIN");
        modelBuilder.HasSequence("VOISSREQ_SEQ", "ADMIN");
        modelBuilder.HasSequence("VOPERDES_SEQ", "ADMIN");
        modelBuilder.HasSequence("VOPERREQ_SEQ", "ADMIN");
        modelBuilder.HasSequence("WACHAT_SEQ", "ADMIN");
        modelBuilder.HasSequence("XPBASE_SEQ", "ADMIN");
        modelBuilder.HasSequence("XPINVIT_SEQ", "ADMIN");
        modelBuilder.HasSequence("XPLAIN_SEQ", "ADMIN");
        modelBuilder.HasSequence("XPORDD_SEQ", "ADMIN");
        modelBuilder.HasSequence("XPPKGD_SEQ", "ADMIN");
        modelBuilder.HasSequence("XPPKGD_SEQ_1", "ADMIN");
        modelBuilder.HasSequence("XPPKNG_SEQ", "ADMIN");

        OnModelCreatingPartial(modelBuilder);

    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
