import { PatientModel } from "./report.request.contract";

export interface DrugRequestContract {
    patient: PatientModel;
    transcripts: string[];
    diagnosis: string;
    symptoms: string[];
}