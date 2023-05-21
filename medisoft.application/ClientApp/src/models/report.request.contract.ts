export interface ReportRequestContract {
    patient: PatientModel;
    transcripts: string[] | undefined;
}

export interface PatientModel {
    name: string;
    age: number;
    gender: string;
    chronicDiseases: string[];
    allergies: string[];
}