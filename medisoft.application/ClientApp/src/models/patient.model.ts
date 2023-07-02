export interface Patient {
    id: number;
    name: string;
    age: number;
    gender: string;
    chronicDiseases: string[];
    allergies: string[];
    patientInformation: PatientInformation[];
}

export interface PatientInformation {
    title: string;
    description: string;
}