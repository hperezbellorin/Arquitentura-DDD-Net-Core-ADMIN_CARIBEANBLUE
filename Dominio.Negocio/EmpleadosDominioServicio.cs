using Dominio.Contratos.UnidadTrabajo;
using Dominio.Entidades.RRHH;
using Dominio.Servicios;
using Infraestructura.DBContext.RRHH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Negocio
{
    public class EmpleadosDominioServicio : IEmpleadosDominioServicios
    {
        private readonly IUnidadTrabajoRRHH unidadTrabajoRRHH;

        public EmpleadosDominioServicio(IUnidadTrabajoRRHH _unidadTrabajoRRHH)
        {
            this.unidadTrabajoRRHH = _unidadTrabajoRRHH;
        }
        public async Task<Empleados> buscarEmpleadosporId(int Id)
        {
            try
            {
                return await unidadTrabajoRRHH.EmpleadosDB.Buscar(Id);
            }
            catch (Exception ex)
            {


                throw new Exception("Ocurrio un problema al buscar empleados",ex);
            }
           
        }

        public async  Task<bool> Create(Empleados empleado)
        {
            try
            {


              

                return await Task.Factory.StartNew(() =>
                {
                    unidadTrabajoRRHH.EmpleadosDB.Add(empleado);
                    unidadTrabajoRRHH.commit();
                    return true;

                });
            }
            catch (Exception ex)
            {

                throw new Exception("Ocurrio un problema al guardar al empleado");
            }
        }

        public async Task<bool> Edit(Empleados empleados)
        {
            try
            {

            var empleadoActual = await buscarEmpleadosporId(empleados.Id);

            empleadoActual.Nombres = empleados.Nombres;
            empleadoActual.Apellido1 = empleados.Apellido1;
            empleadoActual.Cedula = empleados.Cedula;
            empleadoActual.Correo = empleados.Correo;
            return await Task.Factory.StartNew(() =>
            {
                unidadTrabajoRRHH.EmpleadosDB.Update(empleadoActual);
                unidadTrabajoRRHH.commit();
                return true;
            });

            }
            catch (Exception ex)
            {

                throw new Exception("Ocurrio un problema al actualizar al empleado",ex);
            }

        }

        public Task<bool> Eliminar(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Empleados>> GetEmployeesList()
        {
            return unidadTrabajoRRHH.EmpleadosDB.Lista().ToList();
            
        }
    }
}
