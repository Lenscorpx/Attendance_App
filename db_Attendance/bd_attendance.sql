use master;
if exists
    (select * from sys.databases where name='db_attendance')
        drop database db_attendance;
    create database db_attendance;
    use db_attendance;
    create table t_organisations
    (
        num_org int identity,
        id_organisation nvarchar(50),
        nom_organisation nvarchar(50),
        descr_organisation nvarchar(100),
        constraint pk_organisation primary key(id_organisation)
    );
    create table t_employees
        (
            num_emp int identity,
            id_emp nvarchar(50),
            noms_emp nvarchar(100) not null,
            date_naissance date,
            lieu_naissance nvarchar(50),
            adresse nvarchar(100),
            num_phone nvarchar(50),
            id_fonction nvarchar(50),
            id_organisation nvarchar(50),
            constraint pk_employee primary key (id_emp),
            constraint fk_org_emp foreign key(id_organisation) references t_organisations(id_organisation)
        );    
    create table t_attendance
    (
        num_attend int identity,
        date_attendance date,
        id_emp nvarchar(50),
        mov_type nvarchar(50),
        time_attendance datetime,
        observation nvarchar(100),
        constraint pk_attendance primary key(num_attend),
        constraint fk_emp_attend foreign key(id_emp) references t_employees(id_emp)
    ); 
    create table t_users
    (
        num_user int identity,
        id_user nvarchar(50),
        x_passwd nvarchar(50) not null,
        constraint pk_user primary key(id_user)
    );
    create table t_access_level
    (
        num_access int identity,
        id_level_access nvarchar(50),
        descr_access nvarchar(100),
        date_access date,
        constraint pk_access_level primary key(id_level_access)
    );
    create table t_zones
    (
        num_zone int identity,
        id_zone nvarchar(50),
        descr_zone nvarchar(100),
        constraint pk_zone primary key(id_zone)
    );
    create table t_affec_zone
    (
        num_affec_zone int identity,
        id_level_access nvarchar(50),
        id_zone nvarchar(50),
        date_affec_zone datetime,
        constraint pk_affec_zone primary key(num_affec_zone),
        constraint fk_level_affec foreign key(id_level_access) references t_access_level(id_level_access),
        constraint fk_zone_affec foreign key(id_zone) references t_zones(id_zone)
    );

    create table t_accreditation_level
    (
        num_accreditation int identity,
        date_accreditation date,
        id_emp nvarchar(50),
        id_level_access nvarchar(50),
        date_expiration date,
        state_accred nvarchar(50), --- activated or expired
        constraint pk_accreditation primary key(num_accreditation),
        constraint fk_level_accred foreign key(id_level_access) references t_access_level(id_level_access),
        constraint fk_emp_accred foreign key(id_emp) references t_employees(id_emp)
    );
    create table t_suivi
    (
        num_suiv int identity,
        date_suivi datetime,
        id_user nvarchar(50),
        passwrd nvarchar(50),
        state_login nvarchar(50),
        constraint pk_suivi primary key(num_suiv),
        constraint fk_users foreign key(id_user) references t_users(id_user)
    );
    select * from t_employees