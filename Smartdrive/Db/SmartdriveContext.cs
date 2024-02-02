using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Smartdrive.Models;

namespace Smartdrive.Db;

public partial class SmartdriveContext : DbContext
{
    public SmartdriveContext()
    {
    }

    public SmartdriveContext(DbContextOptions<SmartdriveContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AreaWorkgroup> AreaWorkgroups { get; set; }

    public virtual DbSet<Bank> Banks { get; set; }

    public virtual DbSet<BatchEmployeeSalary> BatchEmployeeSalaries { get; set; }

    public virtual DbSet<BatchPartnerInvoice> BatchPartnerInvoices { get; set; }

    public virtual DbSet<BusinessEntity> BusinessEntities { get; set; }

    public virtual DbSet<CarBrand> CarBrands { get; set; }

    public virtual DbSet<CarModel> CarModels { get; set; }

    public virtual DbSet<CarSeries> CarSeries { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<ClaimAssetEvidence> ClaimAssetEvidences { get; set; }

    public virtual DbSet<ClaimAssetSparepart> ClaimAssetSpareparts { get; set; }

    public virtual DbSet<CustomerClaim> CustomerClaims { get; set; }

    public virtual DbSet<CustomerInscAsset> CustomerInscAssets { get; set; }

    public virtual DbSet<CustomerInscDoc> CustomerInscDocs { get; set; }

    public virtual DbSet<CustomerInscExtend> CustomerInscExtends { get; set; }

    public virtual DbSet<CustomerRequest> CustomerRequests { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeAreWorkgroup> EmployeeAreWorkgroups { get; set; }

    public virtual DbSet<EmployeeSalaryDetail> EmployeeSalaryDetails { get; set; }

    public virtual DbSet<Fintech> Finteches { get; set; }

    public virtual DbSet<InsuranceType> InsuranceTypes { get; set; }

    public virtual DbSet<JobType> JobTypes { get; set; }

    public virtual DbSet<Partner> Partners { get; set; }

    public virtual DbSet<PartnerAreaWorkgroup> PartnerAreaWorkgroups { get; set; }

    public virtual DbSet<PartnerContact> PartnerContacts { get; set; }

    public virtual DbSet<PaymentTransaction> PaymentTransactions { get; set; }

    public virtual DbSet<Provinsi> Provinsis { get; set; }

    public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

    public virtual DbSet<RegionPlat> RegionPlats { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<ServiceOrder> ServiceOrders { get; set; }

    public virtual DbSet<ServiceOrderTask> ServiceOrderTasks { get; set; }

    public virtual DbSet<ServiceOrderWorkorder> ServiceOrderWorkorders { get; set; }

    public virtual DbSet<ServicePremi> ServicePremis { get; set; }

    public virtual DbSet<ServicePremiCredit> ServicePremiCredits { get; set; }

    public virtual DbSet<TemplateInsurancePremi> TemplateInsurancePremis { get; set; }

    public virtual DbSet<TemplateSalary> TemplateSalaries { get; set; }

    public virtual DbSet<TemplateServiceTask> TemplateServiceTasks { get; set; }

    public virtual DbSet<TemplateTaskWorkorder> TemplateTaskWorkorders { get; set; }

    public virtual DbSet<TemplateType> TemplateTypes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserAccount> UserAccounts { get; set; }

    public virtual DbSet<UserAddress> UserAddresses { get; set; }

    public virtual DbSet<UserPhone> UserPhones { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    public virtual DbSet<Zone> Zones { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-D6289E0\\SQLEXPRESS; Initial Catalog=Smartdrive; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AreaWorkgroup>(entity =>
        {
            entity.HasKey(e => e.ArwgCode).HasName("PK__area_wor__B0CF95B3957568D0");

            entity.ToTable("area_workgroup", "mtr");

            entity.Property(e => e.ArwgCode)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("arwg_code");
            entity.Property(e => e.ArwgCityId).HasColumnName("arwg_city_id");
            entity.Property(e => e.ArwgDesc)
                .HasMaxLength(55)
                .IsUnicode(false)
                .HasColumnName("arwg_desc");

            entity.HasOne(d => d.ArwgCity).WithMany(p => p.AreaWorkgroups)
                .HasForeignKey(d => d.ArwgCityId)
                .HasConstraintName("FK__area_work__arwg___339FAB6E");
        });

        modelBuilder.Entity<Bank>(entity =>
        {
            entity.HasKey(e => e.BankEntityid).HasName("pk_bank_entityid");

            entity.ToTable("banks", "payment");

            entity.HasIndex(e => e.BankName, "UQ__banks__AEBE098065F0C93C").IsUnique();

            entity.Property(e => e.BankEntityid)
                .ValueGeneratedNever()
                .HasColumnName("bank_entityid");
            entity.Property(e => e.BankDesc)
                .HasMaxLength(55)
                .IsUnicode(false)
                .HasColumnName("bank_desc");
            entity.Property(e => e.BankName)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("bank_name");

            entity.HasOne(d => d.BankEntity).WithOne(p => p.Bank)
                .HasForeignKey<Bank>(d => d.BankEntityid)
                .HasConstraintName("fk_bank_entityid");
        });

        modelBuilder.Entity<BatchEmployeeSalary>(entity =>
        {
            entity.HasKey(e => new { e.BesaEmpEntityId, e.BesaCreatedDate }).HasName("PK__batch_em__D2FFC7DCEB07B8B6");

            entity.ToTable("batch_employee_salary", "hr");

            entity.Property(e => e.BesaEmpEntityId).HasColumnName("besa_emp_entity_id");
            entity.Property(e => e.BesaCreatedDate)
                .HasColumnType("date")
                .HasColumnName("besa_created_date");
            entity.Property(e => e.BesaAccountNumber)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasColumnName("besa_account_number");
            entity.Property(e => e.BesaModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("besa_modified_date");
            entity.Property(e => e.BesaPaidDate)
                .HasColumnType("datetime")
                .HasColumnName("besa_paid_date");
            entity.Property(e => e.BesaPatrTrxno)
                .HasMaxLength(55)
                .IsUnicode(false)
                .HasColumnName("besa_patr_trxno");
            entity.Property(e => e.BesaStatus)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("besa_status");
            entity.Property(e => e.BesaTotalSalary)
                .HasColumnType("money")
                .HasColumnName("besa_total_salary");
            entity.Property(e => e.EmsTrasferDate)
                .HasColumnType("datetime")
                .HasColumnName("ems_trasfer_Date");
        });

        modelBuilder.Entity<BatchPartnerInvoice>(entity =>
        {
            entity.HasKey(e => e.BpinInvoiceNo).HasName("pk_bpin_invoiceNo");

            entity.ToTable("batch_partner_invoice", "partners");

            entity.Property(e => e.BpinInvoiceNo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("bpin_invoiceNo");
            entity.Property(e => e.BpinAccountNo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("bpin_accountNo");
            entity.Property(e => e.BpinCreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("bpin_created_on");
            entity.Property(e => e.BpinPaidDate)
                .HasColumnType("datetime")
                .HasColumnName("bpin_paid_date");
            entity.Property(e => e.BpinPatrTrxno)
                .HasMaxLength(55)
                .IsUnicode(false)
                .HasColumnName("bpin_patr_trxno");
            entity.Property(e => e.BpinPatrnEntityid).HasColumnName("bpin_patrn_entityid");
            entity.Property(e => e.BpinSeroId)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("bpin_sero_id");
            entity.Property(e => e.BpinStatus)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("bpin_status");
            entity.Property(e => e.BpinSubtotal)
                .HasColumnType("money")
                .HasColumnName("bpin_subtotal");
            entity.Property(e => e.BpinTax)
                .HasColumnType("money")
                .HasColumnName("bpin_tax");

            entity.HasOne(d => d.BpinPatrTrxnoNavigation).WithMany(p => p.BatchPartnerInvoices)
                .HasForeignKey(d => d.BpinPatrTrxno)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_bpin_patr_trxno");

            entity.HasOne(d => d.BpinPatrnEntity).WithMany(p => p.BatchPartnerInvoices)
                .HasForeignKey(d => d.BpinPatrnEntityid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_bpin_patrn_entityid");

            entity.HasOne(d => d.BpinSero).WithMany(p => p.BatchPartnerInvoices)
                .HasForeignKey(d => d.BpinSeroId)
                .HasConstraintName("fk_bpin_sero_id");
        });

        modelBuilder.Entity<BusinessEntity>(entity =>
        {
            entity.HasKey(e => e.Entityid).HasName("PK__business__DECC75408490743C");

            entity.ToTable("business_entity", "users");

            entity.Property(e => e.Entityid).HasColumnName("entityid");
            entity.Property(e => e.EntityModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("entity_modified_date");
        });

        modelBuilder.Entity<CarBrand>(entity =>
        {
            entity.HasKey(e => e.CabrId).HasName("PK__car_bran__ED0C67C6C16AC54E");

            entity.ToTable("car_brands", "mtr");

            entity.HasIndex(e => e.CabrName, "UQ__car_bran__750DD7D50E7BCF64").IsUnique();

            entity.Property(e => e.CabrId).HasColumnName("cabr_id");
            entity.Property(e => e.CabrName)
                .HasMaxLength(55)
                .IsUnicode(false)
                .HasColumnName("cabr_name");
        });

        modelBuilder.Entity<CarModel>(entity =>
        {
            entity.HasKey(e => e.CarmId).HasName("PK__car_mode__C680A9539244D4AE");

            entity.ToTable("car_models", "mtr");

            entity.HasIndex(e => e.CarmName, "UQ__car_mode__D13ADFA2846275B5").IsUnique();

            entity.Property(e => e.CarmId).HasColumnName("carm_id");
            entity.Property(e => e.CarmCabrId).HasColumnName("carm_cabr_id");
            entity.Property(e => e.CarmName)
                .HasMaxLength(55)
                .IsUnicode(false)
                .HasColumnName("carm_name");

            entity.HasOne(d => d.CarmCabr).WithMany(p => p.CarModels)
                .HasForeignKey(d => d.CarmCabrId)
                .HasConstraintName("FK__car_model__carm___3493CFA7");
        });

        modelBuilder.Entity<CarSeries>(entity =>
        {
            entity.HasKey(e => e.CarsId).HasName("PK__car_seri__588724E44D6D8ABE");

            entity.ToTable("car_series", "mtr");

            entity.HasIndex(e => e.CarsName, "UQ__car_seri__92361ED82CB3EE42").IsUnique();

            entity.Property(e => e.CarsId).HasColumnName("cars_id");
            entity.Property(e => e.CarsCarmId).HasColumnName("cars_carm_id");
            entity.Property(e => e.CarsName)
                .HasMaxLength(55)
                .IsUnicode(false)
                .HasColumnName("cars_name");
            entity.Property(e => e.CarsPassenger).HasColumnName("cars_passenger");

            entity.HasOne(d => d.CarsCarm).WithMany(p => p.CarSeries)
                .HasForeignKey(d => d.CarsCarmId)
                .HasConstraintName("FK__car_serie__cars___3587F3E0");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CateId).HasName("PK__category__34EAD173456AB7DF");

            entity.ToTable("category", "mtr");

            entity.Property(e => e.CateId).HasColumnName("cate_id");
            entity.Property(e => e.CateName)
                .HasMaxLength(55)
                .IsUnicode(false)
                .HasColumnName("cate_name");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.CityId).HasName("PK__cities__031491A899570127");

            entity.ToTable("cities", "mtr");

            entity.HasIndex(e => e.CityName, "UQ__cities__1AA4F7B5B8CFFB0E").IsUnique();

            entity.Property(e => e.CityId).HasColumnName("city_id");
            entity.Property(e => e.CityName)
                .HasMaxLength(85)
                .IsUnicode(false)
                .HasColumnName("city_name");
            entity.Property(e => e.CityProvId).HasColumnName("city_prov_id");

            entity.HasOne(d => d.CityProv).WithMany(p => p.Cities)
                .HasForeignKey(d => d.CityProvId)
                .HasConstraintName("FK__cities__city_pro__367C1819");
        });

        modelBuilder.Entity<ClaimAssetEvidence>(entity =>
        {
            entity.HasKey(e => e.CaevId).HasName("pk_caev_id");

            entity.ToTable("claim_asset_evidence", "so");

            entity.Property(e => e.CaevId).HasColumnName("caev_id");
            entity.Property(e => e.CaevCreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("caev_created_date");
            entity.Property(e => e.CaevFilename)
                .HasMaxLength(55)
                .IsUnicode(false)
                .HasColumnName("caev_filename");
            entity.Property(e => e.CaevFilesize).HasColumnName("caev_filesize");
            entity.Property(e => e.CaevFiletype)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("caev_filetype");
            entity.Property(e => e.CaevNote)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("caev_note");
            entity.Property(e => e.CaevPartEntityid).HasColumnName("caev_part_entityid");
            entity.Property(e => e.CaevSeroId)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("caev_sero_id");
            entity.Property(e => e.CaevServiceFee)
                .HasColumnType("money")
                .HasColumnName("caev_service_fee");
            entity.Property(e => e.CaevUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("caev_url");

            entity.HasOne(d => d.CaevPartEntity).WithMany(p => p.ClaimAssetEvidences)
                .HasForeignKey(d => d.CaevPartEntityid)
                .HasConstraintName("fk_caev_part_entityid");

            entity.HasOne(d => d.CaevSero).WithMany(p => p.ClaimAssetEvidences)
                .HasForeignKey(d => d.CaevSeroId)
                .HasConstraintName("fk_caev_sero_id");
        });

        modelBuilder.Entity<ClaimAssetSparepart>(entity =>
        {
            entity.HasKey(e => e.CaspId).HasName("pk_casp_id");

            entity.ToTable("claim_asset_sparepart", "so");

            entity.Property(e => e.CaspId).HasColumnName("casp_id");
            entity.Property(e => e.CaspCreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("casp_created_date");
            entity.Property(e => e.CaspItemName)
                .HasMaxLength(55)
                .IsUnicode(false)
                .HasColumnName("casp_item_name");
            entity.Property(e => e.CaspItemPrice)
                .HasColumnType("money")
                .HasColumnName("casp_item_price");
            entity.Property(e => e.CaspPartEntityid).HasColumnName("casp_part_entityid");
            entity.Property(e => e.CaspQuantity).HasColumnName("casp_quantity");
            entity.Property(e => e.CaspSeroId)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("casp_sero_id");
            entity.Property(e => e.CaspSubtotal)
                .HasColumnType("money")
                .HasColumnName("casp_subtotal");

            entity.HasOne(d => d.CaspPartEntity).WithMany(p => p.ClaimAssetSpareparts)
                .HasForeignKey(d => d.CaspPartEntityid)
                .HasConstraintName("fk_casp_part_entityid");

            entity.HasOne(d => d.CaspSero).WithMany(p => p.ClaimAssetSpareparts)
                .HasForeignKey(d => d.CaspSeroId)
                .HasConstraintName("fk_casp_sero_id");
        });

        modelBuilder.Entity<CustomerClaim>(entity =>
        {
            entity.HasKey(e => e.CuclCreqEntityid).HasName("PK__customer__268FDC3944759D50");

            entity.ToTable("customer_claim", "customer");

            entity.Property(e => e.CuclCreqEntityid)
                .ValueGeneratedNever()
                .HasColumnName("cucl_creq_entityid");
            entity.Property(e => e.CuclCreateDate)
                .HasColumnType("datetime")
                .HasColumnName("cucl_create_date");
            entity.Property(e => e.CuclEventPrice)
                .HasColumnType("money")
                .HasColumnName("cucl_event_price");
            entity.Property(e => e.CuclEvents).HasColumnName("cucl_events");
            entity.Property(e => e.CuclReason)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("cucl_reason");
            entity.Property(e => e.CuclSubtotal)
                .HasColumnType("money")
                .HasColumnName("cucl_subtotal");

            entity.HasOne(d => d.CuclCreqEntity).WithOne(p => p.CustomerClaim)
                .HasForeignKey<CustomerClaim>(d => d.CuclCreqEntityid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CUCLCREQ");
        });

        modelBuilder.Entity<CustomerInscAsset>(entity =>
        {
            entity.HasKey(e => e.CiasCreqEntityid).HasName("PK__customer__588FDDBBF66FE15C");

            entity.ToTable("customer_insc_assets", "customer");

            entity.HasIndex(e => e.CiasPoliceNumber, "UQ__customer__E9035C582563EF40").IsUnique();

            entity.Property(e => e.CiasCreqEntityid)
                .ValueGeneratedNever()
                .HasColumnName("cias_creq_entityid");
            entity.Property(e => e.CiasCarsId).HasColumnName("cias_cars_id");
            entity.Property(e => e.CiasCityId).HasColumnName("cias_city_id");
            entity.Property(e => e.CiasCurrentPrice)
                .HasColumnType("money")
                .HasColumnName("cias_current_price");
            entity.Property(e => e.CiasEnddate)
                .HasColumnType("datetime")
                .HasColumnName("cias_enddate");
            entity.Property(e => e.CiasInsurancePrice)
                .HasColumnType("money")
                .HasColumnName("cias_insurance_price");
            entity.Property(e => e.CiasIntyName)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("cias_inty_name");
            entity.Property(e => e.CiasIsNewChar)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cias_isNewChar");
            entity.Property(e => e.CiasPaidType)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("cias_paid_type");
            entity.Property(e => e.CiasPoliceNumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("cias_police_number");
            entity.Property(e => e.CiasStartdate)
                .HasColumnType("datetime")
                .HasColumnName("cias_startdate");
            entity.Property(e => e.CiasTotalPremi)
                .HasColumnType("money")
                .HasColumnName("cias_total_premi");
            entity.Property(e => e.CiasYear)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("cias_year");

            entity.HasOne(d => d.CiasCars).WithMany(p => p.CustomerInscAssets)
                .HasForeignKey(d => d.CiasCarsId)
                .HasConstraintName("FK_CIASCARS");

            entity.HasOne(d => d.CiasCity).WithMany(p => p.CustomerInscAssets)
                .HasForeignKey(d => d.CiasCityId)
                .HasConstraintName("FK_CIASCITY");

            entity.HasOne(d => d.CiasCreqEntity).WithOne(p => p.CustomerInscAsset)
                .HasForeignKey<CustomerInscAsset>(d => d.CiasCreqEntityid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CIASCREQ");

            entity.HasOne(d => d.CiasIntyNameNavigation).WithMany(p => p.CustomerInscAssets)
                .HasForeignKey(d => d.CiasIntyName)
                .HasConstraintName("FK_CIASINTY");
        });

        modelBuilder.Entity<CustomerInscDoc>(entity =>
        {
            entity.HasKey(e => new { e.CadocId, e.CadocCreqEntityid }).HasName("PK_CADOC");

            entity.ToTable("customer_insc_doc", "customer");

            entity.Property(e => e.CadocId).HasColumnName("cadoc_id");
            entity.Property(e => e.CadocCreqEntityid).HasColumnName("cadoc_creq_entityid");
            entity.Property(e => e.CadocCategory)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("cadoc_category");
            entity.Property(e => e.CadocFilename)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("cadoc_filename");
            entity.Property(e => e.CadocFilesize).HasColumnName("cadoc_filesize");
            entity.Property(e => e.CadocFiletype)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("cadoc_filetype");
            entity.Property(e => e.CadocModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("cadoc_modified_date");

            entity.HasOne(d => d.CadocCreqEntity).WithMany(p => p.CustomerInscDocs)
                .HasForeignKey(d => d.CadocCreqEntityid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CADOCCREQ");
        });

        modelBuilder.Entity<CustomerInscExtend>(entity =>
        {
            entity.HasKey(e => new { e.CuexId, e.CuexCreqEntityid }).HasName("PK_CUEX");

            entity.ToTable("customer_insc_extend", "customer");

            entity.Property(e => e.CuexId).HasColumnName("cuex_id");
            entity.Property(e => e.CuexCreqEntityid).HasColumnName("cuex_creq_entityid");
            entity.Property(e => e.CuexName)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("cuex_name");
            entity.Property(e => e.CuexNominal)
                .HasColumnType("money")
                .HasColumnName("cuex_nominal");
            entity.Property(e => e.CuexTotalItem).HasColumnName("cuex_total_item");

            entity.HasOne(d => d.CuexCreqEntity).WithMany(p => p.CustomerInscExtends)
                .HasForeignKey(d => d.CuexCreqEntityid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CUEXCREQ");
        });

        modelBuilder.Entity<CustomerRequest>(entity =>
        {
            entity.HasKey(e => e.CreqEntityid).HasName("PK__customer__606B6AF13875C318");

            entity.ToTable("customer_request", "customer");

            entity.Property(e => e.CreqEntityid)
                .ValueGeneratedNever()
                .HasColumnName("creq_entityid");
            entity.Property(e => e.CreqAgenEntityid).HasColumnName("creq_agen_entityid");
            entity.Property(e => e.CreqCreateDate)
                .HasColumnType("datetime")
                .HasColumnName("creq_create_date");
            entity.Property(e => e.CreqCustEntityid).HasColumnName("creq_cust_entityid");
            entity.Property(e => e.CreqModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("creq_modified_date");
            entity.Property(e => e.CreqStatus)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("creq_status");
            entity.Property(e => e.CreqType)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("creq_type");

            entity.HasOne(d => d.CreqAgenEntity).WithMany(p => p.CustomerRequests)
                .HasPrincipalKey(p => p.EawgId)
                .HasForeignKey(d => d.CreqAgenEntityid)
                .HasConstraintName("FK_CREQAGEN");

            entity.HasOne(d => d.CreqCustEntity).WithMany(p => p.CustomerRequests)
                .HasForeignKey(d => d.CreqCustEntityid)
                .HasConstraintName("FK_CREQENTITY");

            entity.HasOne(d => d.CreqEntity).WithOne(p => p.CustomerRequest)
                .HasForeignKey<CustomerRequest>(d => d.CreqEntityid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CREQCUST_ENTITY");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmpEntityid).HasName("PK__employee__4B2A27D4152DB4D6");

            entity.ToTable("employees", "hr");

            entity.Property(e => e.EmpEntityid)
                .ValueGeneratedNever()
                .HasColumnName("emp_entityid");
            entity.Property(e => e.EmpAccountNumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("emp_account_number");
            entity.Property(e => e.EmpGraduate)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("emp_graduate");
            entity.Property(e => e.EmpJobCode)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("emp_job_code");
            entity.Property(e => e.EmpJoinDate)
                .HasColumnType("datetime")
                .HasColumnName("emp_join_date");
            entity.Property(e => e.EmpModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("emp_modified_date");
            entity.Property(e => e.EmpName)
                .HasMaxLength(85)
                .IsUnicode(false)
                .HasColumnName("emp_name");
            entity.Property(e => e.EmpNetSalary)
                .HasColumnType("money")
                .HasColumnName("emp_net_salary");
            entity.Property(e => e.EmpStatus)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("emp_status");
            entity.Property(e => e.EmpType)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("emp_type");

            entity.HasOne(d => d.EmpEntity).WithOne(p => p.Employee)
                .HasForeignKey<Employee>(d => d.EmpEntityid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__employees__emp_e__31B762FC");

            entity.HasOne(d => d.EmpJobCodeNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.EmpJobCode)
                .HasConstraintName("FK__employees__emp_j__32AB8735");
        });

        modelBuilder.Entity<EmployeeAreWorkgroup>(entity =>
        {
            entity.HasKey(e => new { e.EawgEntityid, e.EawgId }).HasName("PK__employee__0B04DA35AFEBB4D3");

            entity.ToTable("employee_are_workgroup", "hr");

            entity.HasIndex(e => e.EawgId, "UQ__employee__C54750D60F2457E7").IsUnique();

            entity.Property(e => e.EawgEntityid).HasColumnName("eawg_entityid");
            entity.Property(e => e.EawgId).HasColumnName("eawg_id");
            entity.Property(e => e.EawgArwgCode)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("eawg_arwg_code");
            entity.Property(e => e.EawgModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("eawg_modified_date");
            entity.Property(e => e.EawgStatus)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("eawg_status");

            entity.HasOne(d => d.EawgArwgCodeNavigation).WithMany(p => p.EmployeeAreWorkgroups)
                .HasForeignKey(d => d.EawgArwgCode)
                .HasConstraintName("FK__employee___eawg___2FCF1A8A");

            entity.HasOne(d => d.EawgEntity).WithMany(p => p.EmployeeAreWorkgroups)
                .HasForeignKey(d => d.EawgEntityid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__employee___eawg___2EDAF651");
        });

        modelBuilder.Entity<EmployeeSalaryDetail>(entity =>
        {
            entity.HasKey(e => new { e.EmsaId, e.EmsaEmpEntityid, e.EmsaCreateDate }).HasName("PK__employee__027F0DDCBF8C6AA6");

            entity.ToTable("employee_salary_detail", "hr");

            entity.Property(e => e.EmsaId).HasColumnName("emsa_id");
            entity.Property(e => e.EmsaEmpEntityid).HasColumnName("emsa_emp_entityid");
            entity.Property(e => e.EmsaCreateDate)
                .HasColumnType("date")
                .HasColumnName("emsa_create_date");
            entity.Property(e => e.EmsaName)
                .HasMaxLength(55)
                .IsUnicode(false)
                .HasColumnName("emsa_name");
            entity.Property(e => e.EmsaSubtotal)
                .HasColumnType("money")
                .HasColumnName("emsa_subtotal");

            entity.HasOne(d => d.EmsaEmpEntity).WithMany(p => p.EmployeeSalaryDetails)
                .HasForeignKey(d => d.EmsaEmpEntityid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__employee___emsa___30C33EC3");
        });

        modelBuilder.Entity<Fintech>(entity =>
        {
            entity.HasKey(e => e.FintEntityid).HasName("pk_fint_entityid");

            entity.ToTable("fintech", "payment");

            entity.HasIndex(e => e.FintName, "UQ__fintech__96EC4274D72E8208").IsUnique();

            entity.Property(e => e.FintEntityid)
                .ValueGeneratedNever()
                .HasColumnName("fint_entityid");
            entity.Property(e => e.FintDesc)
                .HasMaxLength(55)
                .IsUnicode(false)
                .HasColumnName("fint_desc");
            entity.Property(e => e.FintName)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("fint_name");

            entity.HasOne(d => d.FintEntity).WithOne(p => p.Fintech)
                .HasForeignKey<Fintech>(d => d.FintEntityid)
                .HasConstraintName("fk_fint_entityid");
        });

        modelBuilder.Entity<InsuranceType>(entity =>
        {
            entity.HasKey(e => e.IntyName).HasName("PK__insuranc__38A54D40F4A09CA0");

            entity.ToTable("insurance_type", "mtr");

            entity.Property(e => e.IntyName)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("inty_name");
            entity.Property(e => e.IntyDesc)
                .HasMaxLength(55)
                .IsUnicode(false)
                .HasColumnName("inty_desc");
        });

        modelBuilder.Entity<JobType>(entity =>
        {
            entity.HasKey(e => e.JobCode).HasName("PK__job_type__FBB86DB22559EF71");

            entity.ToTable("job_type", "hr");

            entity.Property(e => e.JobCode)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("job_code");
            entity.Property(e => e.JobDesc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("job_desc");
            entity.Property(e => e.JobModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("job_modified_date");
            entity.Property(e => e.JobRateMax)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("job_rate_max");
            entity.Property(e => e.JobRateMin)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("job_rate_min");
        });

        modelBuilder.Entity<Partner>(entity =>
        {
            entity.HasKey(e => e.PartEntityid).HasName("pk_part_entityid");

            entity.ToTable("partners", "partners");

            entity.Property(e => e.PartEntityid)
                .ValueGeneratedNever()
                .HasColumnName("part_entityid");
            entity.Property(e => e.PartAccountNo)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasColumnName("part_accountNo");
            entity.Property(e => e.PartAddress)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("part_address");
            entity.Property(e => e.PartCityId).HasColumnName("part_city_id");
            entity.Property(e => e.PartJoinDate)
                .HasColumnType("datetime")
                .HasColumnName("part_join_date");
            entity.Property(e => e.PartModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("part_modified_date");
            entity.Property(e => e.PartName)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("part_name");
            entity.Property(e => e.PartNpwp)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("part_npwp");
            entity.Property(e => e.PartStatus)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("part_status");

            entity.HasOne(d => d.PartCity).WithMany(p => p.Partners)
                .HasForeignKey(d => d.PartCityId)
                .HasConstraintName("fk_part_city_id");

            entity.HasOne(d => d.PartEntity).WithOne(p => p.Partner)
                .HasForeignKey<Partner>(d => d.PartEntityid)
                .HasConstraintName("fk_part_entityid");
        });

        modelBuilder.Entity<PartnerAreaWorkgroup>(entity =>
        {
            entity.HasKey(e => new { e.PawoPatrEntityid, e.PawoArwgCode, e.PawoUserEntityid }).HasName("pk_pawo_patr_arwg_user");

            entity.ToTable("partner_area_workgroup", "partners");

            entity.Property(e => e.PawoPatrEntityid).HasColumnName("pawo_patr_entityid");
            entity.Property(e => e.PawoArwgCode)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("pawo_arwg_code");
            entity.Property(e => e.PawoUserEntityid).HasColumnName("pawo_user_entityid");
            entity.Property(e => e.PawoModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("pawo_modified_date");
            entity.Property(e => e.PawoStatus)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("pawo_status");

            entity.HasOne(d => d.PawoArwgCodeNavigation).WithMany(p => p.PartnerAreaWorkgroups)
                .HasForeignKey(d => d.PawoArwgCode)
                .HasConstraintName("fk_pawo_arwg_code");

            entity.HasOne(d => d.Pawo).WithMany(p => p.PartnerAreaWorkgroups)
                .HasForeignKey(d => new { d.PawoPatrEntityid, d.PawoUserEntityid })
                .HasConstraintName("fk_pawo_patr_user");
        });

        modelBuilder.Entity<PartnerContact>(entity =>
        {
            entity.HasKey(e => new { e.PacoPatrnEntityid, e.PacoUserEntityid }).HasName("pk_paco_patrn_user");

            entity.ToTable("partner_contacts", "partners");

            entity.Property(e => e.PacoPatrnEntityid).HasColumnName("paco_patrn_entityid");
            entity.Property(e => e.PacoUserEntityid).HasColumnName("paco_user_entityid");
            entity.Property(e => e.PacoStatus)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("paco_status");

            entity.HasOne(d => d.PacoPatrnEntity).WithMany(p => p.PartnerContacts)
                .HasForeignKey(d => d.PacoPatrnEntityid)
                .HasConstraintName("fk_paco_patrn_entityid");

            entity.HasOne(d => d.PacoUserEntity).WithMany(p => p.PartnerContacts)
                .HasForeignKey(d => d.PacoUserEntityid)
                .HasConstraintName("fk_paco_user_entityid");
        });

        modelBuilder.Entity<PaymentTransaction>(entity =>
        {
            entity.HasKey(e => e.PatrTrxno).HasName("pk_patr_trxno");

            entity.ToTable("payment_transactions", "payment");

            entity.Property(e => e.PatrTrxno)
                .HasMaxLength(55)
                .IsUnicode(false)
                .HasColumnName("patr_trxno");
            entity.Property(e => e.PatrCreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("patr_created_on");
            entity.Property(e => e.PatrCredit)
                .HasColumnType("money")
                .HasColumnName("patr_credit");
            entity.Property(e => e.PatrDebet)
                .HasColumnType("money")
                .HasColumnName("patr_debet");
            entity.Property(e => e.PatrInvoiceNo)
                .HasMaxLength(55)
                .IsUnicode(false)
                .HasColumnName("patr_invoice_no");
            entity.Property(e => e.PatrNotes)
                .HasMaxLength(125)
                .IsUnicode(false)
                .HasColumnName("patr_notes");
            entity.Property(e => e.PatrTrxnoRev)
                .HasMaxLength(55)
                .IsUnicode(false)
                .HasColumnName("patr_trxno_rev");
            entity.Property(e => e.PatrType)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("patr_type");
            entity.Property(e => e.PatrUsacAccountNoFrom)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("patr_usac_accountNo_from");
            entity.Property(e => e.PatrUsacAccountNoTo)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("patr_usac_accountNo_to");

            entity.HasOne(d => d.PatrTrxnoRevNavigation).WithMany(p => p.InversePatrTrxnoRevNavigation)
                .HasForeignKey(d => d.PatrTrxnoRev)
                .HasConstraintName("fk_patr_trxno_rev");
        });

        modelBuilder.Entity<Provinsi>(entity =>
        {
            entity.HasKey(e => e.ProvId).HasName("PK__provinsi__435F53269013E7B0");

            entity.ToTable("provinsi", "mtr");

            entity.HasIndex(e => e.ProvName, "UQ__provinsi__85249846C4CC3348").IsUnique();

            entity.Property(e => e.ProvId).HasColumnName("prov_id");
            entity.Property(e => e.ProvName)
                .HasMaxLength(85)
                .IsUnicode(false)
                .HasColumnName("prov_name");
            entity.Property(e => e.ProvZonesId).HasColumnName("prov_zones_id");

            entity.HasOne(d => d.ProvZones).WithMany(p => p.Provinsis)
                .HasForeignKey(d => d.ProvZonesId)
                .HasConstraintName("FK__provinsi__prov_z__37703C52");
        });

        modelBuilder.Entity<RefreshToken>(entity =>
        {
            entity.HasKey(e => e.RetoId).HasName("pk_reto_id");

            entity.ToTable("refresh_token", "users");

            entity.HasIndex(e => e.RetoToken, "uq_reto_token").IsUnique();

            entity.Property(e => e.RetoId).HasColumnName("reto_id");
            entity.Property(e => e.RetoExpireDate)
                .HasColumnType("date")
                .HasColumnName("reto_expire_date");
            entity.Property(e => e.RetoToken)
                .HasMaxLength(125)
                .IsUnicode(false)
                .HasColumnName("reto_token");
            entity.Property(e => e.RetoUserId).HasColumnName("reto_user_id");

            entity.HasOne(d => d.RetoUser).WithMany(p => p.RefreshTokens)
                .HasForeignKey(d => d.RetoUserId)
                .HasConstraintName("fk_reto_user_id");
        });

        modelBuilder.Entity<RegionPlat>(entity =>
        {
            entity.HasKey(e => e.RegpName).HasName("PK__region_p__187EAC814877EDF7");

            entity.ToTable("region_plat", "mtr");

            entity.Property(e => e.RegpName)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("regp_name");
            entity.Property(e => e.RegpDesc)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasColumnName("regp_desc");
            entity.Property(e => e.RegpProvId).HasColumnName("regp_prov_id");

            entity.HasOne(d => d.RegpProv).WithMany(p => p.RegionPlats)
                .HasForeignKey(d => d.RegpProvId)
                .HasConstraintName("FK__region_pl__regp___3864608B");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleName).HasName("pk_roles");

            entity.ToTable("roles", "users");

            entity.Property(e => e.RoleName)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("role_name");
            entity.Property(e => e.RoleDescription)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasColumnName("role_description");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.ServId).HasName("pk_serv_id");

            entity.ToTable("services", "so");

            entity.Property(e => e.ServId).HasColumnName("serv_id");
            entity.Property(e => e.ServCreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("serv_created_on");
            entity.Property(e => e.ServCreqEntityid).HasColumnName("serv_creq_entityid");
            entity.Property(e => e.ServCustEntityid).HasColumnName("serv_cust_entityid");
            entity.Property(e => e.ServEnddate)
                .HasColumnType("datetime")
                .HasColumnName("serv_enddate");
            entity.Property(e => e.ServInsuranceNo)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("serv_insuranceNo");
            entity.Property(e => e.ServServId).HasColumnName("serv_serv_id");
            entity.Property(e => e.ServStartdate)
                .HasColumnType("datetime")
                .HasColumnName("serv_startdate");
            entity.Property(e => e.ServStatus)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("serv_status");
            entity.Property(e => e.ServType)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("serv_type");
            entity.Property(e => e.ServVehicleNo)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("serv_vehicleNo");

            entity.HasOne(d => d.ServCreqEntity).WithMany(p => p.Services)
                .HasForeignKey(d => d.ServCreqEntityid)
                .HasConstraintName("fk_serv_creq_entityid");

            entity.HasOne(d => d.ServCustEntity).WithMany(p => p.Services)
                .HasForeignKey(d => d.ServCustEntityid)
                .HasConstraintName("fk_serv_cust_entityid");

            entity.HasOne(d => d.ServServ).WithMany(p => p.InverseServServ)
                .HasForeignKey(d => d.ServServId)
                .HasConstraintName("fk_serv_serv_id");
        });

        modelBuilder.Entity<ServiceOrder>(entity =>
        {
            entity.HasKey(e => e.SeroId).HasName("pk_sero_id");

            entity.ToTable("service_orders", "so");

            entity.Property(e => e.SeroId)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("sero_id");
            entity.Property(e => e.SeroAgentEntityid).HasColumnName("sero_agent_entityid");
            entity.Property(e => e.SeroOrdtType)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("sero_ordt_type");
            entity.Property(e => e.SeroPartId).HasColumnName("sero_part_id");
            entity.Property(e => e.SeroReason)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("sero_reason");
            entity.Property(e => e.SeroSeroId)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("sero_sero_id");
            entity.Property(e => e.SeroServId).HasColumnName("sero_serv_id");
            entity.Property(e => e.SeroStatus)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("sero_status");
            entity.Property(e => e.ServClaimEnddate)
                .HasColumnType("datetime")
                .HasColumnName("serv_claim_enddate");
            entity.Property(e => e.ServClaimNo)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("serv_claim_no");
            entity.Property(e => e.ServClaimStartdate)
                .HasColumnType("datetime")
                .HasColumnName("serv_claim_startdate");

            entity.HasOne(d => d.SeroAgentEntity).WithMany(p => p.ServiceOrders)
                .HasPrincipalKey(p => p.EawgId)
                .HasForeignKey(d => d.SeroAgentEntityid)
                .HasConstraintName("fk_sero_eawg_code");

            entity.HasOne(d => d.SeroPart).WithMany(p => p.ServiceOrders)
                .HasForeignKey(d => d.SeroPartId)
                .HasConstraintName("FK_SERO_PART_ID");

            entity.HasOne(d => d.SeroSero).WithMany(p => p.InverseSeroSero)
                .HasForeignKey(d => d.SeroSeroId)
                .HasConstraintName("fk_sero_sero_id");

            entity.HasOne(d => d.SeroServ).WithMany(p => p.ServiceOrders)
                .HasForeignKey(d => d.SeroServId)
                .HasConstraintName("fk_sero_serv_id");
        });

        modelBuilder.Entity<ServiceOrderTask>(entity =>
        {
            entity.HasKey(e => e.SeotId).HasName("pk_seot_id");

            entity.ToTable("service_order_tasks", "so");

            entity.Property(e => e.SeotId).HasColumnName("seot_id");
            entity.Property(e => e.SeotActualEnddate)
                .HasColumnType("datetime")
                .HasColumnName("seot_actual_enddate");
            entity.Property(e => e.SeotActualStartdate)
                .HasColumnType("datetime")
                .HasColumnName("seot_actual_startdate");
            entity.Property(e => e.SeotArwgCode)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("seot_arwg_code");
            entity.Property(e => e.SeotEnddate)
                .HasColumnType("datetime")
                .HasColumnName("seot_enddate");
            entity.Property(e => e.SeotName)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("seot_name");
            entity.Property(e => e.SeotSeroId)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("seot_sero_id");
            entity.Property(e => e.SeotStartdate)
                .HasColumnType("datetime")
                .HasColumnName("seot_startdate");
            entity.Property(e => e.SeotStatus)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("seot_status");

            entity.HasOne(d => d.SeotArwgCodeNavigation).WithMany(p => p.ServiceOrderTasks)
                .HasForeignKey(d => d.SeotArwgCode)
                .HasConstraintName("fk_seot_arwg_code");

            entity.HasOne(d => d.SeotSero).WithMany(p => p.ServiceOrderTasks)
                .HasForeignKey(d => d.SeotSeroId)
                .HasConstraintName("fk_seot_sero_id");
        });

        modelBuilder.Entity<ServiceOrderWorkorder>(entity =>
        {
            entity.HasKey(e => e.SowoId).HasName("pk_sowo_id");

            entity.ToTable("service_order_workorder", "so");

            entity.Property(e => e.SowoId).HasColumnName("sowo_id");
            entity.Property(e => e.SowoModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("sowo_modified_date");
            entity.Property(e => e.SowoName)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("sowo_name");
            entity.Property(e => e.SowoSeotId).HasColumnName("sowo_seot_id");
            entity.Property(e => e.SowoStatus)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("sowo_status");

            entity.HasOne(d => d.SowoSeot).WithMany(p => p.ServiceOrderWorkorders)
                .HasForeignKey(d => d.SowoSeotId)
                .HasConstraintName("fk_sowo_seot_id");
        });

        modelBuilder.Entity<ServicePremi>(entity =>
        {
            entity.HasKey(e => e.SemiServId).HasName("pk_semi_serv_id");

            entity.ToTable("service_premi", "so");

            entity.Property(e => e.SemiServId)
                .ValueGeneratedNever()
                .HasColumnName("semi_serv_id");
            entity.Property(e => e.SemiModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("semi_modified_date");
            entity.Property(e => e.SemiPaidType)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("semi_paid_type");
            entity.Property(e => e.SemiPremiCredit)
                .HasColumnType("money")
                .HasColumnName("semi_premi_credit");
            entity.Property(e => e.SemiPremiDebet)
                .HasColumnType("money")
                .HasColumnName("semi_premi_debet");
            entity.Property(e => e.SemiStatus)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("semi_status");

            entity.HasOne(d => d.SemiServ).WithOne(p => p.ServicePremi)
                .HasForeignKey<ServicePremi>(d => d.SemiServId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_semi_serv_id");
        });

        modelBuilder.Entity<ServicePremiCredit>(entity =>
        {
            entity.HasKey(e => new { e.SecrId, e.SecrServId }).HasName("pk_secr");

            entity.ToTable("service_premi_credit", "so");

            entity.Property(e => e.SecrId).HasColumnName("secr_id");
            entity.Property(e => e.SecrServId).HasColumnName("secr_serv_id");
            entity.Property(e => e.SecrDuedate)
                .HasColumnType("datetime")
                .HasColumnName("secr_duedate");
            entity.Property(e => e.SecrPatrTrxno)
                .HasMaxLength(55)
                .IsUnicode(false)
                .HasColumnName("secr_patr_trxno");
            entity.Property(e => e.SecrPremiCredit)
                .HasColumnType("money")
                .HasColumnName("secr_premi_credit");
            entity.Property(e => e.SecrPremiDebet)
                .HasColumnType("money")
                .HasColumnName("secr_premi_debet");
            entity.Property(e => e.SecrTrxDate)
                .HasColumnType("datetime")
                .HasColumnName("secr_trx_date");
            entity.Property(e => e.SecrYear)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("secr_year");

            entity.HasOne(d => d.SecrPatrTrxnoNavigation).WithMany(p => p.ServicePremiCredits)
                .HasForeignKey(d => d.SecrPatrTrxno)
                .HasConstraintName("fk_secr_patr_trxno");

            entity.HasOne(d => d.SecrServ).WithMany(p => p.ServicePremiCredits)
                .HasForeignKey(d => d.SecrServId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_secr_serv_id");
        });

        modelBuilder.Entity<TemplateInsurancePremi>(entity =>
        {
            entity.HasKey(e => e.TemiId).HasName("PK__template__3E626865C787F371");

            entity.ToTable("template_insurance_premi", "mtr");

            entity.Property(e => e.TemiId).HasColumnName("temi_id");
            entity.Property(e => e.TemiCateId).HasColumnName("temi_cate_id");
            entity.Property(e => e.TemiIntyName)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("temi_inty_name");
            entity.Property(e => e.TemiName)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("temi_name");
            entity.Property(e => e.TemiNominal).HasColumnName("temi_nominal");
            entity.Property(e => e.TemiRateMax).HasColumnName("temi_rate_max");
            entity.Property(e => e.TemiRateMin).HasColumnName("temi_rate_min");
            entity.Property(e => e.TemiType)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("temi_type");
            entity.Property(e => e.TemiZonesId).HasColumnName("temi_zones_id");

            entity.HasOne(d => d.TemiCate).WithMany(p => p.TemplateInsurancePremis)
                .HasForeignKey(d => d.TemiCateId)
                .HasConstraintName("FK__template___temi___3B40CD36");

            entity.HasOne(d => d.TemiIntyNameNavigation).WithMany(p => p.TemplateInsurancePremis)
                .HasForeignKey(d => d.TemiIntyName)
                .HasConstraintName("FK__template___temi___3A4CA8FD");

            entity.HasOne(d => d.TemiZones).WithMany(p => p.TemplateInsurancePremis)
                .HasForeignKey(d => d.TemiZonesId)
                .HasConstraintName("FK__template___temi___395884C4");
        });

        modelBuilder.Entity<TemplateSalary>(entity =>
        {
            entity.HasKey(e => e.TesalId).HasName("PK__template__C273C168D0E00179");

            entity.ToTable("template_salary", "hr");

            entity.Property(e => e.TesalId).HasColumnName("tesal_id");
            entity.Property(e => e.TesalName)
                .HasMaxLength(55)
                .IsUnicode(false)
                .HasColumnName("tesal_name");
            entity.Property(e => e.TesalNominal)
                .HasColumnType("money")
                .HasColumnName("tesal_nominal");
            entity.Property(e => e.TesalRateMax).HasColumnName("tesal_rate_max");
            entity.Property(e => e.TesalRateMin).HasColumnName("tesal_rate_min");
        });

        modelBuilder.Entity<TemplateServiceTask>(entity =>
        {
            entity.HasKey(e => e.TestaId).HasName("PK__template__5FE71914EAD00496");

            entity.ToTable("template_service_task", "mtr");

            entity.Property(e => e.TestaId).HasColumnName("testa_id");
            entity.Property(e => e.TestaCallmethod)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("testa_callmethod");
            entity.Property(e => e.TestaGroup)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("testa_group");
            entity.Property(e => e.TestaName)
                .HasMaxLength(55)
                .IsUnicode(false)
                .HasColumnName("testa_name");
            entity.Property(e => e.TestaSeqorder).HasColumnName("testa_seqorder");
            entity.Property(e => e.TestaTetyId).HasColumnName("testa_tety_id");

            entity.HasOne(d => d.TestaTety).WithMany(p => p.TemplateServiceTasks)
                .HasForeignKey(d => d.TestaTetyId)
                .HasConstraintName("FK__template___testa__3C34F16F");
        });

        modelBuilder.Entity<TemplateTaskWorkorder>(entity =>
        {
            entity.HasKey(e => e.TewoId).HasName("PK__template__5130424C122F3224");

            entity.ToTable("template_task_workorder", "mtr");

            entity.Property(e => e.TewoId).HasColumnName("tewo_id");
            entity.Property(e => e.TewoName)
                .HasMaxLength(55)
                .IsUnicode(false)
                .HasColumnName("tewo_name");
            entity.Property(e => e.TewoTestaId).HasColumnName("tewo_testa_id");
            entity.Property(e => e.TewoValue)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tewo_value");

            entity.HasOne(d => d.TewoTesta).WithMany(p => p.TemplateTaskWorkorders)
                .HasForeignKey(d => d.TewoTestaId)
                .HasConstraintName("FK__template___tewo___3D2915A8");
        });

        modelBuilder.Entity<TemplateType>(entity =>
        {
            entity.HasKey(e => e.TetyId).HasName("PK__template__895AF6C90A055980");

            entity.ToTable("template_type", "mtr");

            entity.HasIndex(e => e.TetyName, "UQ__template__F5145B12BCCBC94E").IsUnique();

            entity.Property(e => e.TetyId).HasColumnName("tety_id");
            entity.Property(e => e.TetyGroup)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("tety_group");
            entity.Property(e => e.TetyName)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("tety_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserEntityid).HasName("PK__users__32806B062C124882");

            entity.ToTable("users", "users");

            entity.HasIndex(e => e.UserNpwp, "UQ__users__58883F86948D5F0A").IsUnique();

            entity.HasIndex(e => e.UserNationalId, "UQ__users__60A5BA8FEC602D45").IsUnique();

            entity.HasIndex(e => e.UserName, "user_name_UQ")
                .IsUnique()
                .HasFilter("([user_name] IS NOT NULL)");

            entity.Property(e => e.UserEntityid)
                .ValueGeneratedNever()
                .HasColumnName("user_entityid");
            entity.Property(e => e.UserBirthDate)
                .HasColumnType("datetime")
                .HasColumnName("user_birth_date");
            entity.Property(e => e.UserBirthPlace)
                .HasMaxLength(55)
                .IsUnicode(false)
                .HasColumnName("user_birth_place");
            entity.Property(e => e.UserEmail)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("user_email");
            entity.Property(e => e.UserFullName)
                .HasMaxLength(85)
                .IsUnicode(false)
                .HasColumnName("user_full_name");
            entity.Property(e => e.UserModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("user_modified_date");
            entity.Property(e => e.UserName)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("user_name");
            entity.Property(e => e.UserNationalId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("user_national_id");
            entity.Property(e => e.UserNpwp)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasColumnName("user_npwp");
            entity.Property(e => e.UserPassword)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("user_password");
            entity.Property(e => e.UserPhoto)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("user_photo");

            entity.HasOne(d => d.UserEntity).WithOne(p => p.User)
                .HasForeignKey<User>(d => d.UserEntityid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__users__user_enti__625A9A57");
        });

        modelBuilder.Entity<UserAccount>(entity =>
        {
            entity.HasKey(e => e.UsacId).HasName("pk_usac_id");

            entity.ToTable("user_accounts", "payment");

            entity.HasIndex(e => e.UsacAccountno, "UQ__user_acc__87A4C64B1D0CDC82").IsUnique();

            entity.Property(e => e.UsacId).HasColumnName("usac_id");
            entity.Property(e => e.UsacAccountno)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("usac_accountno");
            entity.Property(e => e.UsacBankEntityid).HasColumnName("usac_bank_entityid");
            entity.Property(e => e.UsacCredit)
                .HasColumnType("money")
                .HasColumnName("usac_credit");
            entity.Property(e => e.UsacDebet)
                .HasColumnType("money")
                .HasColumnName("usac_debet");
            entity.Property(e => e.UsacFintEntityid).HasColumnName("usac_fint_entityid");
            entity.Property(e => e.UsacType)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("usac_type");
            entity.Property(e => e.UsacUserEntityid).HasColumnName("usac_user_entityid");

            entity.HasOne(d => d.UsacBankEntity).WithMany(p => p.UserAccounts)
                .HasForeignKey(d => d.UsacBankEntityid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_usac_bank_entityid");

            entity.HasOne(d => d.UsacFintEntity).WithMany(p => p.UserAccounts)
                .HasForeignKey(d => d.UsacFintEntityid)
                .HasConstraintName("fk_usac_fint_entityid");

            entity.HasOne(d => d.UsacUserEntity).WithMany(p => p.UserAccounts)
                .HasForeignKey(d => d.UsacUserEntityid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_user_entityid");
        });

        modelBuilder.Entity<UserAddress>(entity =>
        {
            entity.HasKey(e => new { e.UsdrId, e.UsdrEntityid }).HasName("pk_entity_address");

            entity.ToTable("user_address", "users");

            entity.Property(e => e.UsdrId).HasColumnName("usdr_id");
            entity.Property(e => e.UsdrEntityid).HasColumnName("usdr_entityid");
            entity.Property(e => e.UsdrAddress1)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("usdr_address1");
            entity.Property(e => e.UsdrAddress2)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("usdr_address2");
            entity.Property(e => e.UsdrCityId).HasColumnName("usdr_city_id");
            entity.Property(e => e.UsdrModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("usdr_modified_date");

            entity.HasOne(d => d.UsdrCity).WithMany(p => p.UserAddresses)
                .HasForeignKey(d => d.UsdrCityId)
                .HasConstraintName("fk_address_cities");

            entity.HasOne(d => d.UsdrEntity).WithMany(p => p.UserAddresses)
                .HasForeignKey(d => d.UsdrEntityid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_entity_address_users");
        });

        modelBuilder.Entity<UserPhone>(entity =>
        {
            entity.HasKey(e => new { e.UsphEntityid, e.UsphPhoneNumber }).HasName("pk_entity_phone");

            entity.ToTable("user_phone", "users");

            entity.Property(e => e.UsphEntityid).HasColumnName("usph_entityid");
            entity.Property(e => e.UsphPhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("usph_phone_number");
            entity.Property(e => e.UsphMime)
                .HasMaxLength(512)
                .IsUnicode(false)
                .HasColumnName("usph_mime");
            entity.Property(e => e.UsphModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("usph_modified_date");
            entity.Property(e => e.UsphPhoneType)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("usph_phone_type");
            entity.Property(e => e.UsphStatus)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("usph_status");

            entity.HasOne(d => d.UsphEntity).WithMany(p => p.UserPhones)
                .HasForeignKey(d => d.UsphEntityid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_entityid_phone");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => new { e.UsroEntityid, e.UsroRoleName }).HasName("pk_usro");

            entity.ToTable("user_roles", "users");

            entity.Property(e => e.UsroEntityid).HasColumnName("usro_entityid");
            entity.Property(e => e.UsroRoleName)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("usro_role_name");
            entity.Property(e => e.UsroModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("usro_modified_date");
            entity.Property(e => e.UsroStatus)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("usro_status");

            entity.HasOne(d => d.UsroEntity).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.UsroEntityid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_entity_usro_users");

            entity.HasOne(d => d.UsroRoleNameNavigation).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.UsroRoleName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__user_role__usro___607251E5");
        });

        modelBuilder.Entity<Zone>(entity =>
        {
            entity.HasKey(e => e.ZonesId).HasName("PK__zones__D409535DA9F7BB23");

            entity.ToTable("zones", "mtr");

            entity.Property(e => e.ZonesId).HasColumnName("zones_id");
            entity.Property(e => e.ZonesName)
                .HasMaxLength(55)
                .IsUnicode(false)
                .HasColumnName("zones_name");
        });
        modelBuilder.HasSequence("besa_emp_entity_id", "hr").HasMin(1L);
        modelBuilder.HasSequence("cadoc_cuex_id");
        modelBuilder.HasSequence("employee_are_workgroup_seq", "hr").HasMin(1L);
        modelBuilder.HasSequence("emsa_id").HasMin(1L);
        modelBuilder.HasSequence("emsa_id", "hr").HasMin(1L);
        modelBuilder.HasSequence("serc_seq");
        modelBuilder.HasSequence("user_address_seq", "users")
            .StartsAt(2L)
            .HasMin(2L);

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
