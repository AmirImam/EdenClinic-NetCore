
using EdenClinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdenClinic.Service
{
    public class ServiceContext
    {

        private ODataSet<T> GetInistance<T>(ODataSet<T> obj) where T : class
        {
            if (obj == null)
            {
                obj = new ODataSet<T>(Configuration);
            }
            return obj;
        }
       
        public ServiceContext()
        {
            _configuration = new ODataConfiguration();
        }

        public ServiceContext(string token)
        {
            _configuration = new ODataConfiguration();
            _configuration.AccessToken = token;
        }

        

        private ODataConfiguration _configuration;
        public ODataConfiguration Configuration
        {
            get
            {
                return _configuration;
            }
        }
       
        public ODataSet<Center> Centers => new ODataSet<Center>(Configuration);
public ODataSet<Clinic> Clinics => new ODataSet<Clinic>(Configuration);
public ODataSet<ClinicalHistory> ClinicalHistories => new ODataSet<ClinicalHistory>(Configuration);
public ODataSet<Diagnosis> Diagnoses => new ODataSet<Diagnosis>(Configuration);
public ODataSet<Disease> Diseases => new ODataSet<Disease>(Configuration);
public ODataSet<DiseaseCategory> DiseaseCategories => new ODataSet<DiseaseCategory>(Configuration);
public ODataSet<DoctorSetting> DoctorSettings => new ODataSet<DoctorSetting>(Configuration);
public ODataSet<Drug> Drugs => new ODataSet<Drug>(Configuration);
public ODataSet<MedicalHistory> MedicalHistories => new ODataSet<MedicalHistory>(Configuration);
public ODataSet<MedicalHistoryCaption> MedicalHistoryCaptions => new ODataSet<MedicalHistoryCaption>(Configuration);
public ODataSet<MedicalProcedure> MedicalProcedures => new ODataSet<MedicalProcedure>(Configuration);
public ODataSet<MedicalTest> MedicalTests => new ODataSet<MedicalTest>(Configuration);
public ODataSet<MedicalTestsDetail> MedicalTestsDetails => new ODataSet<MedicalTestsDetail>(Configuration);
public ODataSet<PatientInfo> PatientInfoes => new ODataSet<PatientInfo>(Configuration);
public ODataSet<PatientMedicalHistory> PatientMedicalHistories => new ODataSet<PatientMedicalHistory>(Configuration);
public ODataSet<Person> Persons => new ODataSet<Person>(Configuration);
public ODataSet<Prescription> Prescriptions => new ODataSet<Prescription>(Configuration);
public ODataSet<PrescriptionDetail> PrescriptionDetails => new ODataSet<PrescriptionDetail>(Configuration);
public ODataSet<Remark> Remarks => new ODataSet<Remark>(Configuration);
public ODataSet<Reservation> Reservations => new ODataSet<Reservation>(Configuration);
public ODataSet<SystemRole> Roles => new ODataSet<SystemRole>(Configuration);
public ODataSet<RolePage> RolePages => new ODataSet<RolePage>(Configuration);
public ODataSet<Specialist> Specialists => new ODataSet<Specialist>(Configuration);
public ODataSet<SystemAction> SystemActions => new ODataSet<SystemAction>(Configuration);
public ODataSet<TestTemplate> TestTemplates => new ODataSet<TestTemplate>(Configuration);
public ODataSet<TestTemplateDetail> TestTemplateDetails => new ODataSet<TestTemplateDetail>(Configuration);
public ODataSet<Treasury> Treasuries => new ODataSet<Treasury>(Configuration);
public ODataSet<Treatment> Treatments => new ODataSet<Treatment>(Configuration);
public ODataSet<TreatmentCategory> TreatmentCategories => new ODataSet<TreatmentCategory>(Configuration);
public ODataSet<WorkingSheet> WorkingSheets => new ODataSet<WorkingSheet>(Configuration);
public ODataSet<SystemRole> SystemRoles => new ODataSet<SystemRole>(Configuration);
//##Sets##






        
    }



}
