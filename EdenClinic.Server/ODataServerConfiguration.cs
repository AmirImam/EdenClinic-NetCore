/*
*
* Generated At 9/7/2020 7:47:07 AM
*
*/
using Microsoft.AspNetCore.Builder;
using Microsoft.OData.Edm;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNetCore.Routing;
using EdenClinic.Models;
namespace EdenClinic.Server
{
    public class ODataServerConfiguration
    {
         //You must call this method at Startup.cs -> app.UseMvc

        public static void Config(IRouteBuilder builder)
        {
            builder.Select().Filter().Expand().Count().OrderBy().MaxTop(null);
            builder.MapODataServiceRoute("api", "api", GetOdataModel());
        }
        private static IEdmModel GetOdataModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Center>(nameof(Center));
builder.EntitySet<Clinic>(nameof(Clinic));
builder.EntitySet<ClinicalHistory>(nameof(ClinicalHistory));
builder.EntitySet<Diagnosis>(nameof(Diagnosis));
builder.EntitySet<Disease>(nameof(Disease));
builder.EntitySet<DiseaseCategory>(nameof(DiseaseCategory));
builder.EntitySet<DoctorSetting>(nameof(DoctorSetting));
builder.EntitySet<Drug>(nameof(Drug));
builder.EntitySet<MedicalHistory>(nameof(MedicalHistory));
builder.EntitySet<MedicalHistoryCaption>(nameof(MedicalHistoryCaption));
builder.EntitySet<MedicalProcedure>(nameof(MedicalProcedure));
builder.EntitySet<MedicalTest>(nameof(MedicalTest));
builder.EntitySet<MedicalTestsDetail>(nameof(MedicalTestsDetail));
builder.EntitySet<PatientInfo>(nameof(PatientInfo));
builder.EntitySet<PatientMedicalHistory>(nameof(PatientMedicalHistory));
builder.EntitySet<Person>(nameof(Person));
builder.EntitySet<Prescription>(nameof(Prescription));
builder.EntitySet<PrescriptionDetail>(nameof(PrescriptionDetail));
builder.EntitySet<Remark>(nameof(Remark));
builder.EntitySet<Reservation>(nameof(Reservation));
builder.EntitySet<Role>(nameof(Role));
builder.EntitySet<RolePage>(nameof(RolePage));
builder.EntitySet<Specialist>(nameof(Specialist));
builder.EntitySet<SystemAction>(nameof(SystemAction));
builder.EntitySet<TestTemplate>(nameof(TestTemplate));
builder.EntitySet<TestTemplateDetail>(nameof(TestTemplateDetail));
builder.EntitySet<Treasury>(nameof(Treasury));
builder.EntitySet<Treatment>(nameof(Treatment));
builder.EntitySet<TreatmentCategory>(nameof(TreatmentCategory));
builder.EntitySet<WorkingSheet>(nameof(WorkingSheet));
//##EntitiesSets##





            return builder.GetEdmModel();
        }
    }
}