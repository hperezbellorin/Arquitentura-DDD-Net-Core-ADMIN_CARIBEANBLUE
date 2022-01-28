using Aplicacion.Contratos;
using Aplicacion.EntidadesDto;
using Dominio.Entidades.RRHH;
using Dominio.Servicios;
using InfraestructuraTransversal.General.Utilitarios;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Servicio
{
    public class EmpleadosAplicacionServicio : IEmpleadosAplicacionServicio
    {
        private IEmpleadosDominioServicios empleadosDominioServicio;
        public EmpleadosAplicacionServicio(IEmpleadosDominioServicios _empleadosDominioServicio)
        {
            this.empleadosDominioServicio = _empleadosDominioServicio;
        }

        public async Task<bool> actualizarEmpleado(EmpleadosDto empleado)
        {
            try
            {
                Empleados emp = new Empleados();
                if (empleado != null)
                {
                    emp.Id = empleado.Id;
                    emp.Nombres = empleado.Nombres;
                    emp.Apellido1 = empleado.Apellido1;
                    emp.Cedula = empleado.Cedula;
                    emp.Correo = empleado.Correo;
                }

                return await empleadosDominioServicio.Edit(emp);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<EmpleadosDto> buscarempleadoporId(int Id)
        {
            try
            {
                EmpleadosDto empDto = new EmpleadosDto();
                var employees = await empleadosDominioServicio.buscarEmpleadosporId(Id);

              
              if(employees != null)
                {
                    empDto.Nombres = General.ValidateNullorEmptySTRING(employees.Nombres.TrimEnd());
                    if (employees.Apellido1 != null) { General.ValidateNullorEmptySTRING(employees.Apellido1.TrimEnd()); }
                    
                    empDto.Cedula = General.ValidateNullorEmptySTRING(employees.Cedula.TrimEnd());
                    empDto.Correo = General.ValidateNullorEmptySTRING(employees.Correo.TrimEnd());

                }
                    
              
                return empDto;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<bool> eliminarEmpleado(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<EmpleadosDto>> GetEmleadosList()
        {
            var empleadoslist = await empleadosDominioServicio.GetEmployeesList();

           

            List<EmpleadosDto> empleadosDtosList = new List<EmpleadosDto>();

            foreach (var item in empleadoslist)
            {
                EmpleadosDto dto = new EmpleadosDto();
                dto.Id  = item.Id;
                dto.Nombres = item.Nombres;
                dto.Apellido1 = item.Apellido1;
                dto.Cedula = item.Cedula;
                dto.Correo = item.Correo;
                empleadosDtosList.Add(dto);
            }

            return empleadosDtosList;
        }

        public  async Task<bool> guardarEmpleado(EmpleadosDto empleado)
        {
            Empleados emp = new Empleados();
            if (empleado != null)
            {
               
            emp.Nombres = General.ValidateNullorEmptySTRING(empleado.Nombres.TrimEnd());
            emp.Apellido1 = General.ValidateNullorEmptySTRING(empleado.Apellido1.TrimEnd());
            emp.Correo = General.ValidateNullorEmptySTRING(empleado.Correo.TrimEnd());
            //emp.fi = DateTime.Now.ToString();
            emp.Cedula = General.ValidateNullorEmptySTRING(empleado.Cedula.TrimEnd());
                emp.Estado = "1";
            emp.IsActive = true;
            }

            return  await empleadosDominioServicio.Create(emp);

        }
    }
}
