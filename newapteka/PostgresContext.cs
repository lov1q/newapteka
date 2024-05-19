using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace newapteka;

public partial class PostgresContext : DbContext
{
    public PostgresContext()
    {
    }

    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Courier> Couriers { get; set; }

    public virtual DbSet<Discount> Discounts { get; set; }

    public virtual DbSet<DiscountsForCustomer> DiscountsForCustomers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Employee1> Employees1 { get; set; }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<OrderForHome> OrderForHomes { get; set; }

    public virtual DbSet<Pharmacy> Pharmacies { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Procurement> Procurements { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductAccordingToRecipe> ProductAccordingToRecipes { get; set; }

    public virtual DbSet<Provider> Providers { get; set; }

    public virtual DbSet<PurchaseDetail> PurchaseDetails { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Salary> Salaries { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<Stock> Stocks { get; set; }

    public virtual DbSet<StolenProduct> StolenProducts { get; set; }

    public virtual DbSet<SuppliesOfGood> SuppliesOfGoods { get; set; }

    public virtual DbSet<Supply> Supplies { get; set; }

    public virtual DbSet<TotalPurchasePeriod> TotalPurchasePeriods { get; set; }

    public virtual DbSet<TradingPlan> TradingPlans { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=12345");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("pg_catalog", "adminpack");

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ИндексКлиента).HasName("клиенты_pkey");

            entity.ToTable("clients");

            entity.Property(e => e.ИндексКлиента)
                .ValueGeneratedNever()
                .HasColumnName("Индекс_клиента");
            entity.Property(e => e.ДатаРождения).HasColumnName("Дата_рождения");
            entity.Property(e => e.Имя).HasMaxLength(15);
            entity.Property(e => e.Отчество)
                .HasMaxLength(25)
                .HasDefaultValueSql("NULL::character varying");
            entity.Property(e => e.Телефон).HasMaxLength(20);
            entity.Property(e => e.Фамилия).HasMaxLength(17);
        });

        modelBuilder.Entity<Courier>(entity =>
        {
            entity.HasKey(e => e.ИндексКурьера).HasName("курьер_pkey");

            entity.ToTable("courier");

            entity.Property(e => e.ИндексКурьера)
                .ValueGeneratedNever()
                .HasColumnName("Индекс_Курьера");
            entity.Property(e => e.Имя).HasMaxLength(15);
            entity.Property(e => e.Отчество)
                .HasMaxLength(20)
                .HasDefaultValueSql("NULL::character varying");
            entity.Property(e => e.Телефон)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.Транспорт).HasMaxLength(45);
            entity.Property(e => e.Фамилия).HasMaxLength(20);
        });

        modelBuilder.Entity<Discount>(entity =>
        {
            entity.HasKey(e => e.ИндексСкидки).HasName("скидки_pkey");

            entity.ToTable("discounts");

            entity.Property(e => e.ИндексСкидки)
                .ValueGeneratedNever()
                .HasColumnName("Индекс_Скидки");
            entity.Property(e => e.ДатаНачала).HasColumnName("Дата_начала");
            entity.Property(e => e.ДатаОкончания).HasColumnName("Дата_окончания");
            entity.Property(e => e.НазвваниеСкидки)
                .HasMaxLength(25)
                .HasColumnName("Назввание_скидки");
            entity.Property(e => e.Описание).HasMaxLength(45);
            entity.Property(e => e.Скидка).HasColumnName("Скидка(%)");
        });

        modelBuilder.Entity<DiscountsForCustomer>(entity =>
        {
            entity.HasKey(e => e.ИндексСкидкиДляКлиентов).HasName("скидки_для_клиентов_pkey");

            entity.ToTable("discounts_for_customers");

            entity.Property(e => e.ИндексСкидкиДляКлиентов)
                .ValueGeneratedNever()
                .HasColumnName("Индекс_Скидки_для_клиентов");
            entity.Property(e => e.ИндексКлиента).HasColumnName("Индекс_Клиента");
            entity.Property(e => e.ИндексСкидки).HasColumnName("Индекс_Скидки");

            entity.HasOne(d => d.ИндексКлиентаNavigation).WithMany(p => p.DiscountsForCustomers)
                .HasForeignKey(d => d.ИндексКлиента)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Индекс_Кллиента");

            entity.HasOne(d => d.ИндексСкидкиNavigation).WithMany(p => p.DiscountsForCustomers)
                .HasForeignKey(d => d.ИндексСкидки)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Индекс_Сккидки");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.ИндексСотрудника).HasName("сотрудники_pkey");

            entity.ToTable("employees");

            entity.Property(e => e.ИндексСотрудника)
                .ValueGeneratedNever()
                .HasColumnName("Индекс_Сотрудника");
            entity.Property(e => e.Адрес).HasMaxLength(45);
            entity.Property(e => e.Имя).HasMaxLength(30);
            entity.Property(e => e.ИндексАптеки).HasColumnName("Индекс_Аптеки");
            entity.Property(e => e.Образование).HasMaxLength(45);
            entity.Property(e => e.Отчество)
                .HasMaxLength(35)
                .HasDefaultValueSql("NULL::character varying");
            entity.Property(e => e.Пол).HasMaxLength(1);
            entity.Property(e => e.Телефон)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.Фамилия).HasMaxLength(35);

            entity.HasOne(d => d.ДолжностьNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.Должность)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Индекс_должности");

            entity.HasOne(d => d.ИндексАптекиNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.ИндексАптеки)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Индекс_Аптек");
        });

        modelBuilder.Entity<Employee1>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("employee");

            entity.Property(e => e.Имя).HasMaxLength(30);
            entity.Property(e => e.Отчество).HasMaxLength(35);
            entity.Property(e => e.Фамилия).HasMaxLength(35);
        });

        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.HasKey(e => e.ИндексПроизводителя).HasName("производитель_pkey");

            entity.ToTable("manufacturer");

            entity.Property(e => e.ИндексПроизводителя)
                .ValueGeneratedNever()
                .HasColumnName("Индекс_Производителя");
            entity.Property(e => e.НазваниеПроизводителя)
                .HasMaxLength(100)
                .HasColumnName("Название_производителя");
            entity.Property(e => e.СтранаПроизводителя)
                .HasMaxLength(50)
                .HasColumnName("Страна_производителя");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.ИндексДеталейЗаказа).HasName("детали_заказа_pkey");

            entity.ToTable("order_details");

            entity.Property(e => e.ИндексДеталейЗаказа)
                .ValueGeneratedNever()
                .HasColumnName("Индекс_Деталей_заказа");
            entity.Property(e => e.ИндексЗаказаНаДом).HasColumnName("Индекс_Заказа_на_дом");
            entity.Property(e => e.ИндкесТовара).HasColumnName("Индкес_Товара");

            entity.HasOne(d => d.ИндексЗаказаНаДомNavigation).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ИндексЗаказаНаДом)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Индекс_Заказа_на_дом");

            entity.HasOne(d => d.ИндкесТовараNavigation).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ИндкесТовара)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Индекс_Товаррра");
        });

        modelBuilder.Entity<OrderForHome>(entity =>
        {
            entity.HasKey(e => e.ИндексЗаказаНаДом).HasName("заказ_на_дом_pkey");

            entity.ToTable("order_for_home");

            entity.Property(e => e.ИндексЗаказаНаДом)
                .ValueGeneratedNever()
                .HasColumnName("Индекс_Заказа_на_дом");
            entity.Property(e => e.ДатаДоставки).HasColumnName("Дата_доставки");
            entity.Property(e => e.ДатаЗаказа).HasColumnName("Дата_заказа");
            entity.Property(e => e.ИндексКлиента).HasColumnName("Индекс_Клиента");
            entity.Property(e => e.ИндексКурьера).HasColumnName("Индекс_Курьера");
            entity.Property(e => e.СуммаДоставки).HasColumnName("Сумма_доставки");

            entity.HasOne(d => d.ИндексКлиентаNavigation).WithMany(p => p.OrderForHomes)
                .HasForeignKey(d => d.ИндексКлиента)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Индекс_Клиентта");

            entity.HasOne(d => d.ИндексКурьераNavigation).WithMany(p => p.OrderForHomes)
                .HasForeignKey(d => d.ИндексКурьера)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Индекс_Курьерра");
        });

        modelBuilder.Entity<Pharmacy>(entity =>
        {
            entity.HasKey(e => e.ИндексАптеки).HasName("аптека_pkey");

            entity.ToTable("pharmacy");

            entity.Property(e => e.ИндексАптеки)
                .ValueGeneratedNever()
                .HasColumnName("Индекс_Аптеки");
            entity.Property(e => e.Адрес).HasMaxLength(45);
            entity.Property(e => e.ГрафикРаботы)
                .HasMaxLength(45)
                .HasColumnName("График_работы");
            entity.Property(e => e.Название).HasMaxLength(45);
            entity.Property(e => e.Телефон)
                .HasMaxLength(20)
                .IsFixedLength();
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.ИндексДолжности).HasName("должности_pkey");

            entity.ToTable("positions");

            entity.Property(e => e.ИндексДолжности)
                .ValueGeneratedNever()
                .HasColumnName("Индекс_должности");
            entity.Property(e => e.НазваниеДолжности)
                .HasMaxLength(45)
                .HasColumnName("Название_должности");
        });

        modelBuilder.Entity<Procurement>(entity =>
        {
            entity.HasKey(e => e.ИндексЗакупки).HasName("закупки_pkey");

            entity.ToTable("procurement");

            entity.Property(e => e.ИндексЗакупки)
                .ValueGeneratedNever()
                .HasColumnName("Индекс_Закупки");
            entity.Property(e => e.ДатаЗакупки).HasColumnName("Дата_закупки");
            entity.Property(e => e.ИндексАптеки).HasColumnName("Индекс_Аптеки");
            entity.Property(e => e.ИндексСклада).HasColumnName("Индекс_Склада");
            entity.Property(e => e.СуммаЗакупки).HasColumnName("Сумма_закупки");

            entity.HasOne(d => d.ИндексАптекиNavigation).WithMany(p => p.Procurements)
                .HasForeignKey(d => d.ИндексАптеки)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Индекс_Аптеки");

            entity.HasOne(d => d.ИндексСкладаNavigation).WithMany(p => p.Procurements)
                .HasForeignKey(d => d.ИндексСклада)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Индекс_склада");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ИндексТовара).HasName("Товар_pkey");

            entity.ToTable("product");

            entity.Property(e => e.ИндексТовара)
                .ValueGeneratedNever()
                .HasColumnName("Индекс_Товара");
            entity.Property(e => e.КатегорияТовара)
                .HasMaxLength(100)
                .HasColumnName("Категория_товара");
            entity.Property(e => e.Название).HasMaxLength(45);
            entity.Property(e => e.УсловиеХранения)
                .HasMaxLength(10)
                .HasColumnName("Условие хранения");

            entity.HasOne(d => d.ПроизводительNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.Производитель)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Производитель");
        });

        modelBuilder.Entity<ProductAccordingToRecipe>(entity =>
        {
            entity.HasKey(e => e.ИндексРецепта).HasName("товар_по_рецепту_pkey");

            entity.ToTable("product_according to_recipe");

            entity.Property(e => e.ИндексРецепта)
                .ValueGeneratedNever()
                .HasColumnName("Индекс_Рецепта");
            entity.Property(e => e.Врач).HasMaxLength(45);
            entity.Property(e => e.ДатаВыпискиРецепта).HasColumnName("Дата_выписки_рецепта");
            entity.Property(e => e.ДатаПокупкиТовара).HasColumnName("Дата_покупки_товара");
            entity.Property(e => e.ИндексКлиента).HasColumnName("Индекс_Клиента");
            entity.Property(e => e.ИндексТовара).HasColumnName("Индекс_Товара");

            entity.HasOne(d => d.ИндексКлиентаNavigation).WithMany(p => p.ProductAccordingToRecipes)
                .HasForeignKey(d => d.ИндексКлиента)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Индекс_Клиентааа");

            entity.HasOne(d => d.ИндексТовараNavigation).WithMany(p => p.ProductAccordingToRecipes)
                .HasForeignKey(d => d.ИндексТовара)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Индекс_Товараааа");
        });

        modelBuilder.Entity<Provider>(entity =>
        {
            entity.HasKey(e => e.ИндексПоставщика).HasName("поставщики_pkey");

            entity.ToTable("provider");

            entity.Property(e => e.ИндексПоставщика)
                .ValueGeneratedNever()
                .HasColumnName("Индекс_Поставщика");
            entity.Property(e => e.Имя).HasMaxLength(30);
            entity.Property(e => e.КомпанияПоставщика)
                .HasMaxLength(45)
                .HasColumnName("Компания_поставщика");
            entity.Property(e => e.Отчество)
                .HasMaxLength(35)
                .HasDefaultValueSql("NULL::character varying");
            entity.Property(e => e.Телефон)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.Фамилия).HasMaxLength(35);
        });

        modelBuilder.Entity<PurchaseDetail>(entity =>
        {
            entity.HasKey(e => e.ИндексДеталиЗакупки).HasName("детали_закупки_pkey");

            entity.ToTable("purchase_details");

            entity.Property(e => e.ИндексДеталиЗакупки)
                .ValueGeneratedNever()
                .HasColumnName("Индекс_Детали_закупки");
            entity.Property(e => e.ИндексЗакупки).HasColumnName("Индекс_Закупки");
            entity.Property(e => e.ИндексТовара).HasColumnName("Индекс_Товара");

            entity.HasOne(d => d.ИндексЗакупкиNavigation).WithMany(p => p.PurchaseDetails)
                .HasForeignKey(d => d.ИндексЗакупки)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Индекс_Закупок");

            entity.HasOne(d => d.ИндексТовараNavigation).WithMany(p => p.PurchaseDetails)
                .HasForeignKey(d => d.ИндексТовара)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Индекс_Товара");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.IdReview).HasName("отзывы_pkey");

            entity.ToTable("reviews");

            entity.Property(e => e.IdReview)
                .ValueGeneratedNever()
                .HasColumnName("idReview");
            entity.Property(e => e.DateOfReview).HasColumnName("dateOfReview");
            entity.Property(e => e.IdClient).HasColumnName("idClient");
            entity.Property(e => e.Review1)
                .HasMaxLength(255)
                .HasColumnName("review");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.IdClient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Индекс_Клиента");
        });

        modelBuilder.Entity<Salary>(entity =>
        {
            entity.HasKey(e => e.ИндексЗарплаты).HasName("зарплата_pkey");

            entity.ToTable("salary");

            entity.Property(e => e.ИндексЗарплаты)
                .ValueGeneratedNever()
                .HasColumnName("Индекс_зарплаты");
            entity.Property(e => e.ДатаВыплаты)
                .HasMaxLength(15)
                .HasColumnName("Дата_выплаты");
            entity.Property(e => e.ИндексСотрудника).HasColumnName("Индекс_Сотрудника");
            entity.Property(e => e.СуммаВыплаты).HasColumnName("Сумма_выплаты");

            entity.HasOne(d => d.ИндексСотрудникаNavigation).WithMany(p => p.Salaries)
                .HasForeignKey(d => d.ИндексСотрудника)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Индекс_Сотрудника");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.ИндексПродажи).HasName("продажи_pkey");

            entity.ToTable("sales");

            entity.Property(e => e.ИндексПродажи)
                .ValueGeneratedNever()
                .HasColumnName("Индекс_Продажи");
            entity.Property(e => e.ДатаПродажи).HasColumnName("Дата_продажи");
            entity.Property(e => e.ИндексАптеки).HasColumnName("Индекс_Аптеки");
            entity.Property(e => e.ИндексСкидки).HasColumnName("Индекс_Скидки");
            entity.Property(e => e.ИндексТовара).HasColumnName("Индекс_Товара");
            entity.Property(e => e.КоличествоТовара).HasColumnName("Количество_товара");

            entity.HasOne(d => d.ИндексАптекиNavigation).WithMany(p => p.Sales)
                .HasForeignKey(d => d.ИндексАптеки)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Индекс_Аптекии");

            entity.HasOne(d => d.ИндексСкидкиNavigation).WithMany(p => p.Sales)
                .HasForeignKey(d => d.ИндексСкидки)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Индекс_Скидки");

            entity.HasOne(d => d.ИндексТовараNavigation).WithMany(p => p.Sales)
                .HasForeignKey(d => d.ИндексТовара)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Индекс_Товарааа");
        });

        modelBuilder.Entity<Stock>(entity =>
        {
            entity.HasKey(e => e.ИндексСклада).HasName("склад_pkey");

            entity.ToTable("stock");

            entity.Property(e => e.ИндексСклада)
                .ValueGeneratedNever()
                .HasColumnName("Индекс_Склада");
            entity.Property(e => e.АдресСклада)
                .HasMaxLength(50)
                .HasColumnName("Адрес_склада");
            entity.Property(e => e.ОбъемСклада)
                .HasMaxLength(15)
                .HasColumnName("Объем_склада");
        });

        modelBuilder.Entity<StolenProduct>(entity =>
        {
            entity.HasKey(e => e.ИндексСписанныхТоваров).HasName("списанные_товары_pkey");

            entity.ToTable("stolen_products");

            entity.Property(e => e.ИндексСписанныхТоваров)
                .ValueGeneratedNever()
                .HasColumnName("Индекс_Списанных_товаров");
            entity.Property(e => e.ДатаСписания).HasColumnName("Дата_списания");
            entity.Property(e => e.ИндексАптеки).HasColumnName("Индекс_Аптеки");
            entity.Property(e => e.ИндексТовара).HasColumnName("Индекс_Товара");
            entity.Property(e => e.ПричинаСписания)
                .HasMaxLength(45)
                .HasColumnName("Причина_списания");

            entity.HasOne(d => d.ИндексАптекиNavigation).WithMany(p => p.StolenProducts)
                .HasForeignKey(d => d.ИндексАптеки)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Индекс_Аптекки");

            entity.HasOne(d => d.ИндексТовараNavigation).WithMany(p => p.StolenProducts)
                .HasForeignKey(d => d.ИндексТовара)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Индекс_Товаара");
        });

        modelBuilder.Entity<SuppliesOfGood>(entity =>
        {
            entity.HasKey(e => e.ИндексПоставокТовара).HasName("поставки_товара_pkey");

            entity.ToTable("supplies_of goods");

            entity.Property(e => e.ИндексПоставокТовара)
                .ValueGeneratedNever()
                .HasColumnName("Индекс_Поставок_товара");
            entity.Property(e => e.ИндексПоставки).HasColumnName("Индекс_Поставки");
            entity.Property(e => e.ИндексТовара).HasColumnName("Индекс_Товара");

            entity.HasOne(d => d.ИндексПоставкиNavigation).WithMany(p => p.SuppliesOfGoods)
                .HasForeignKey(d => d.ИндексПоставки)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Индекс_Поставки");

            entity.HasOne(d => d.ИндексТовараNavigation).WithMany(p => p.SuppliesOfGoods)
                .HasForeignKey(d => d.ИндексТовара)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Индекс_Товараа");
        });

        modelBuilder.Entity<Supply>(entity =>
        {
            entity.HasKey(e => e.ИндексПоставки).HasName("поставки_pkey");

            entity.ToTable("supplies");

            entity.Property(e => e.ИндексПоставки)
                .ValueGeneratedNever()
                .HasColumnName("Индекс_Поставки");
            entity.Property(e => e.ДатаПоставки).HasColumnName("Дата_поставки");
            entity.Property(e => e.ИндексПоставщика).HasColumnName("Индекс_Поставщика");
            entity.Property(e => e.ИндексСклада).HasColumnName("Индекс_Склада");

            entity.HasOne(d => d.ИндексПоставщикаNavigation).WithMany(p => p.Supplies)
                .HasForeignKey(d => d.ИндексПоставщика)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Индекс_Поставщикаа");

            entity.HasOne(d => d.ИндексСкладаNavigation).WithMany(p => p.Supplies)
                .HasForeignKey(d => d.ИндексСклада)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Индекс_Складаа");
        });

        modelBuilder.Entity<TotalPurchasePeriod>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("total_purchase_period");

            entity.Property(e => e.PurchaseDate).HasColumnName("purchase_date");
            entity.Property(e => e.TotalPurchase).HasColumnName("total_purchase");
        });

        modelBuilder.Entity<TradingPlan>(entity =>
        {
            entity.HasKey(e => e.ИндексТорговогоПлана).HasName("торговый_план_pkey");

            entity.ToTable("trading_plan");

            entity.Property(e => e.ИндексТорговогоПлана)
                .ValueGeneratedNever()
                .HasColumnName("Индекс_Торгового_плана");
            entity.Property(e => e.ИндексАптеки).HasColumnName("Индекс_Аптеки");
            entity.Property(e => e.ИндексСотрудника).HasColumnName("Индекс_Сотрудника");
            entity.Property(e => e.ИндексТовара).HasColumnName("Индекс_Товара");
            entity.Property(e => e.Статус).HasMaxLength(15);

            entity.HasOne(d => d.ИндексАптекиNavigation).WithMany(p => p.TradingPlans)
                .HasForeignKey(d => d.ИндексАптеки)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Индекс_Аптееки");

            entity.HasOne(d => d.ИндексСотрудникаNavigation).WithMany(p => p.TradingPlans)
                .HasForeignKey(d => d.ИндексСотрудника)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Индекс_Сотрудддд");

            entity.HasOne(d => d.ИндексТовараNavigation).WithMany(p => p.TradingPlans)
                .HasForeignKey(d => d.ИндексТовара)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Индекс_Товвара");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.ИндексПользователя).HasName("пользователи_pkey");

            entity.ToTable("users");

            entity.Property(e => e.ИндексПользователя)
                .ValueGeneratedNever()
                .HasColumnName("Индекс_пользователя");
            entity.Property(e => e.Должность).HasMaxLength(255);
            entity.Property(e => e.Логин).HasMaxLength(255);
            entity.Property(e => e.Пароль).HasMaxLength(255);
            entity.Property(e => e.Соль).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
