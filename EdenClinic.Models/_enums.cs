public class GenericModel
{
    public string Value { get; set; }
}
public enum UserStates
{
    Pending,
    Active,
    Blocked
}

public enum UserJob
{
    Doctor,
    Receptionist,
    LabSpecialist,
    NotUser,
    Accountant
}
public enum Diangosies
{
    General,
    Caries,
    Filling,
    Prosthatics,
    Pulb
}
public enum PatientDetectingState
{
    OnReservation,
    ReadyToDetect,
    InDetecting,
    FinishedDetecting,
    Closed
}

//public enum RoleTypes
//{
//    Admin,
//    Dentist,
//    Doctor,
//    LabSpecialist,
//    Receptionist,
//    NotUser,
//    Accountant
//}

public enum Ganders
{
    Male,
    Female
}

public enum MaritalStatus
{
    Signle,
    Married,
    Divorced
}