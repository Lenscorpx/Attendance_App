create procedure search_zone_infos_code
    @id_emp nvarchar(50)
    as
    select        
        t_affec_zone.id_zone
    from            
        t_access_level inner join
        t_accreditation_level on 
            t_access_level.id_level_access = t_accreditation_level.id_level_access inner join
                t_affec_zone on 
                    t_access_level.id_level_access = t_affec_zone.id_level_access inner join
                         t_employees on t_accreditation_level.id_emp = t_employees.id_emp
    where 
        t_accreditation_level.id_emp like @id_emp 
		go
create procedure search_accesslevel_infos_code
@id_emp nvarchar(50)
as
select top 1       
    t_accreditation_level.id_level_access
from            
    t_access_level inner join
    t_accreditation_level on 
        t_access_level.id_level_access = t_accreditation_level.id_level_access inner join
            t_affec_zone on 
                t_access_level.id_level_access = t_affec_zone.id_level_access inner join
                        t_employees on t_accreditation_level.id_emp = t_employees.id_emp
where 
    t_accreditation_level.id_emp like @id_emp	
go
create procedure search_infos_code
@id_emp nvarchar(50)
as
select top 1 
	t_employees.noms_emp, 
	t_employees.id_fonction,
	t_employees.id_organisation,
	t_employees.num_phone,
	t_employees.adresse    
from            
    t_access_level inner join
    t_accreditation_level on 
        t_access_level.id_level_access = t_accreditation_level.id_level_access inner join
            t_affec_zone on 
                t_access_level.id_level_access = t_affec_zone.id_level_access inner join
                        t_employees on t_accreditation_level.id_emp = t_employees.id_emp
where 
    t_accreditation_level.id_emp like @id_emp
go
create procedure afficher_employees
as
	select top 20
		id_emp as 'ID',
		noms_emp as 'Noms',
		adresse as 'Adresse',
		num_phone as 'Telephone',
		id_fonction as 'Fonction O.',
		id_organisation as 'Organisation'
	from t_employees
		order by
			noms_emp desc
go
create procedure search_employee_byid
@id_emp as nvarchar(50)
as
	select top 20
		id_emp as 'ID',
		noms_emp as 'Noms',
		adresse as 'Adresse',
		num_phone as 'Telephone',
		id_fonction as 'Fonction O.',
		id_organisation as 'Organisation'
	from t_employees
		where
			id_emp like '%'+@id_emp+'%'
	go
create procedure search_employee_byname
@noms_emp as nvarchar(50)
	as
		select top 20
			id_emp as 'ID',
			noms_emp as 'Noms',
			adresse as 'Adresse',
			num_phone as 'Telephone',
			id_fonction as 'Fonction O.',
			id_organisation as 'Organisation'
		from t_employees
			where
				noms_emp like '%'+@noms_emp+'%'
		go
create procedure search_employee_byfonction
@id_fonction as nvarchar(50)
	as
		select top 20
			id_emp as 'ID',
			noms_emp as 'Noms',
			adresse as 'Adresse',
			num_phone as 'Telephone',
			id_fonction as 'Fonction O.',
			id_organisation as 'Organisation'
		from t_employees
			where
				id_fonction like '%'+@id_fonction+'%'
		go
create procedure search_employee_byorganisation
@id_organisation as nvarchar(50)
	as
		select top 20
			id_emp as 'ID',
			noms_emp as 'Noms',
			adresse as 'Adresse',
			num_phone as 'Telephone',
			id_fonction as 'Fonction O.',
			id_organisation as 'Organisation'
		from t_employees
			where
				id_organisation like '%'+@id_organisation+'%'
		go
create procedure retrieve_combo_organization
as
	select 
		id_organisation
	from t_organisations
		order by id_organisation asc
go
create procedure afficher_employees_full
as
	select top 20
		num_emp as 'Num. Enr',
		id_emp as 'ID',
		noms_emp as 'Noms',
		adresse as 'Adresse',
		num_phone as 'Telephone',
		id_fonction as 'Fonction O.',
		id_organisation as 'Organisation'
	from t_employees
		order by
			noms_emp desc 
go
create procedure enregistrer_employee
@id_emp nvarchar(50),
@noms_emp nvarchar(50),
@adresse nvarchar(100),
@num_phone nvarchar(50),
@id_fonction nvarchar(50),
@id_organisation nvarchar(50)
as
	insert into t_employees
		(id_emp,noms_emp,adresse,num_phone,id_fonction,id_organisation)
	values
		(@id_emp,@noms_emp,@adresse,@num_phone,@id_fonction,@id_organisation)
go
create procedure modifier_employee
@num_emp int,
@id_emp nvarchar(50),
@noms_emp nvarchar(50),
@adresse nvarchar(100),
@num_phone nvarchar(50),
@id_fonction nvarchar(50),
@id_organisation nvarchar(50)
as
	update t_employees
	set
		id_emp=@id_emp,
		noms_emp=@noms_emp,
		adresse=@adresse,
		num_phone=@num_phone,
		id_fonction=@id_fonction,
		id_organisation=@id_organisation
	where
		num_emp=@num_emp
	go
create procedure supprimer_employee
@num_emp int
as
	delete from t_employees
		where
			num_emp=@num_emp
go
create procedure search_employee_byid_full
@id_emp as nvarchar(50)
	as
		select top 20
		num_emp as 'Num_emp',
			id_emp as 'ID',
			noms_emp as 'Noms',
			adresse as 'Adresse',
			num_phone as 'Telephone',
			id_fonction as 'Fonction O.',
			id_organisation as 'Organisation'
		from t_employees
			where
				id_emp like '%'+@id_emp+'%'
		go
create procedure search_employee_byname_full
@noms_emp as nvarchar(50)
	as
		select top 20
		num_emp as 'Num_emp',
			id_emp as 'ID',
			noms_emp as 'Noms',
			adresse as 'Adresse',
			num_phone as 'Telephone',
			id_fonction as 'Fonction O.',
			id_organisation as 'Organisation'
		from t_employees
			where
				noms_emp like '%'+@noms_emp+'%'
		go
create procedure search_employee_byfonction_full
@id_fonction as nvarchar(50)
	as
		select top 20
		num_emp as 'Num_emp',
			id_emp as 'ID',
			noms_emp as 'Noms',
			adresse as 'Adresse',
			num_phone as 'Telephone',
			id_fonction as 'Fonction O.',
			id_organisation as 'Organisation'
		from t_employees
			where
				id_fonction like '%'+@id_fonction+'%'
		go
create procedure search_employee_byorganisation_full
@id_organisation as nvarchar(50)
	as
		select top 20
			num_emp as 'Num_emp',
			id_emp as 'ID',
			noms_emp as 'Noms',
			adresse as 'Adresse',
			num_phone as 'Telephone',
			id_fonction as 'Fonction O.',
			id_organisation as 'Organisation'
		from t_employees
			where
				id_organisation like '%'+@id_organisation+'%'
		go
create procedure afficher_attendance
as	
	select top 30
	    t_attendance.num_attend, 
		t_attendance.date_attendance, 
		t_attendance.id_emp, 
		t_employees.noms_emp, 
		t_employees.id_organisation, 
        t_attendance.time_attendance
	from           
		t_attendance inner join
              t_employees on 
					dbo.t_attendance.id_emp = t_employees.id_emp
		order by
			t_attendance.time_attendance desc
go
create procedure enregistrer_attendance
@date_attendance date,
@id_emp nvarchar(50),
@time_attendance datetime
as
	insert into t_attendance
		(date_attendance,id_emp,time_attendance)
	values
		(@date_attendance,@id_emp,@time_attendance)
go
create procedure search_attendance_byid
@id_emp as nvarchar(50)
	as
		select top 30
			t_attendance.num_attend, 
			t_attendance.date_attendance, 
			t_attendance.id_emp, 
			t_employees.noms_emp, 
			t_employees.id_organisation, 
			t_attendance.time_attendance
		from           
			t_attendance inner join
				  t_employees on 
						dbo.t_attendance.id_emp = t_employees.id_emp
				where
					t_attendance.id_emp like '%'+@id_emp+'%'
			order by time_attendance desc
go
create procedure search_attendance_byname
@noms_emp as nvarchar(50)
	as
		select top 30
			t_attendance.num_attend, 
			t_attendance.date_attendance, 
			t_attendance.id_emp, 
			t_employees.noms_emp, 
			t_employees.id_organisation, 
			t_attendance.time_attendance
		from           
			t_attendance inner join
				  t_employees on 
						dbo.t_attendance.id_emp = t_employees.id_emp
				where
					t_employees.noms_emp like '%'+@noms_emp+'%'
			order by time_attendance desc
go
create procedure search_attendance_byorganisation
@id_organisation as nvarchar(50)
	as
		select top 30
			t_attendance.num_attend, 
			t_attendance.date_attendance, 
			t_attendance.id_emp, 
			t_employees.noms_emp, 
			t_employees.id_organisation, 
			t_attendance.time_attendance
		from           
			t_attendance inner join
				  t_employees on 
						dbo.t_attendance.id_emp = t_employees.id_emp
				where
					t_employees.id_organisation like '%'+@id_organisation+'%'
			order by time_attendance desc
go
create procedure retrieve_combo_zone
as
select
	 id_zone
from t_zones
	order by id_zone asc
go
create procedure retrieve_combo_level
as
	select
		id_level_access
	from t_access_level
		order by id_level_access asc
go
create procedure afficher_affectation_zone
as
	select top 30
		t_affec_zone.num_affec_zone,
		t_affec_zone.id_level_access,
		t_affec_zone.id_zone,
		t_affec_zone.date_affec_zone
	from t_affec_zone
		order by id_level_access asc, id_zone asc
go
create procedure enregistrer_affectation
@id_level_access nvarchar(50),
@id_zone nvarchar(50),
@date_affec_zone datetime
as
	insert into t_affec_zone	
		(id_level_access,id_zone,date_affec_zone)
	values
		(@id_level_access,@id_zone,@date_affec_zone)
	go
create procedure modifier_affectation
@num_affec_zone int,
@id_level_access nvarchar(50),
@id_zone nvarchar(50),
@date_affec_zone datetime
as
	update t_affec_zone
		set
			id_level_access=@id_level_access,
			id_zone=@id_zone,
			date_affec_zone=@date_affec_zone
		where
			num_affec_zone=@num_affec_zone
	go
create procedure supprimer_affectation
@num_affec_zone int
as
	delete from t_affec_zone
		where num_affec_zone=@num_affec_zone
go
create procedure search_affec_zone_by_id_zone
@id_zone nvarchar(50)
as
	select 
		id_level_access,
		id_zone
	from t_affec_zone
		where
			id_zone like '%'+@id_zone+'%'
		order by
			date_affec_zone desc
go
create procedure search_affec_zone_by_id_level_access
@id_level_access nvarchar(50)
as
	select 
		id_level_access,
		id_zone
	from t_affec_zone
		where
			id_level_access like'%'+@id_level_access+'%'
		order by
			date_affec_zone desc
go
create procedure enregistrer_accreditation
@date_accreditation date,
@id_emp nvarchar(50),
@id_level_access nvarchar(50),
@date_expiration date,
@state_accred nvarchar(50)
as
	insert into t_accreditation_level
		(date_accreditation,id_emp,id_level_access,date_expiration,state_accred)
	values
		(@date_accreditation,@id_emp,@id_level_access,@date_expiration,@state_accred)
go
create procedure modifier_accreditation
@num_accreditation int,
@date_accreditation date,
@id_emp nvarchar(50),
@id_level_access nvarchar(50),
@date_expiration date,
@state_accred nvarchar(50)
as
	update t_accreditation_level
		set
			date_accreditation=@date_accreditation,
			id_emp=@id_emp,
			id_level_access=@id_level_access,
			date_expiration=@date_expiration,
			state_accred=@state_accred
		where
			num_accreditation=@num_accreditation
go
create procedure supprimer_accreditation
@num_accreditation int
as
	delete from t_accreditation_level
		where
			num_accreditation like @num_accreditation
go
create procedure afficher_accreditation
as
	select top 30
		num_accreditation,
		date_accreditation,
		id_emp,
		id_level_access,
		date_expiration
	from t_accreditation_level
		order by
			num_accreditation desc
go
create procedure search_accreditation
@id_emp nvarchar(50)
as
	select top 30
		num_accreditation,
		date_accreditation,
		id_emp,
		id_level_access,
		date_expiration
	from t_accreditation_level
		where id_emp like '%'+@id_emp+'%'
go
create procedure afficher_zone
as
	select top 30
		num_zone,
		id_zone,
		descr_zone
	from t_zones
		order by
			num_zone desc
go
create procedure enregistrer_zone
@id_zone nvarchar(50),
@descr_zone nvarchar(100)
as
	insert into t_zones
		(id_zone,descr_zone)
	values
		(@id_zone,@descr_zone)
go
create procedure modifier_zone
@num_zone int,
@id_zone nvarchar(50),
@descr_zone nvarchar(100)
as
	update t_zones	
		set
			descr_zone=@descr_zone
	where
		num_zone=@num_zone
go
create procedure supprimer_zone
@num_zone int
as
	delete from t_zones
		where 
			num_zone=@num_zone
go
create procedure search_zone
@id_zone nvarchar(50)
as
	select top 30
		num_zone,
		id_zone,
		descr_zone
	from t_zones
		where
			id_zone like '%'+@id_zone+'%'
		order by
			num_zone desc
go
create procedure afficher_organisation
as
	select top 30
		num_org,
		id_organisation,
		nom_organisation,
		descr_organisation
	from t_organisations
		order by
			num_org desc
go
create procedure enregistrer_organisation
@id_organisation nvarchar(50),
@nom_organisation nvarchar(50),
@descr_organisation nvarchar(100)
as
	insert into t_organisations
		(id_organisation,nom_organisation,descr_organisation)
	values
		(@id_organisation,@nom_organisation,@descr_organisation)
go
create procedure modifier_organisation
@num_org int,
@id_organisation nvarchar(50),
@nom_organisation nvarchar(50),
@descr_organisation nvarchar(100)
as
	update t_organisations	
		set
		nom_organisation=@nom_organisation,
		descr_organisation=@descr_organisation
	where
		num_org=@num_org
go
create procedure supprimer_organisation
@num_org int
as
	delete from t_organisations
		where 
			num_org=@num_org
go
create procedure search_organisation
@id_organisation nvarchar(50)
as
	select top 30
		num_org,
		id_organisation,
		nom_organisation,
		descr_organisation
	from t_organisations
		where
			id_organisation like '%'+@id_organisation+'%'
		order by
			num_org desc
go
create procedure afficher_level
as
	select top 30
		num_access,
		id_level_access,
		descr_access,
		date_access
	from t_access_level
		order by
			num_access desc
go
create procedure enregistrer_level
@id_level_access nvarchar(50),
@descr_access nvarchar(100),
@date_access date
as
	insert into t_access_level
		(id_level_access,descr_access,date_access)
	values
		(@id_level_access,@descr_access,@date_access)
go
create procedure modifier_level
@num_access int,
@id_level_access nvarchar(50),
@descr_access nvarchar(100),
@date_access date
as
	update t_access_level	
		set
		descr_access=@descr_access,
		date_access=@date_access
	where
		num_access=@num_access
go
create procedure supprimer_level
@num_access int
as
	delete from t_access_level
		where 
			num_access=@num_access
go
create procedure search_level
@id_access_level nvarchar(50)
as
	select top 30
		num_access,
		id_level_access,
		descr_access,
		date_access
	from t_access_level
		where
			id_level_access like '%'+@id_access_level+'%'
		order by
			num_access desc
go


	