export interface BardReportModel {
    diagnosis: Diagnosis;
    diagnosisExplaination: string;
    drugOfChoice: DrugOfChoice;
    symptoms: Symptoms[];
}

export interface Symptoms {
    name: string;
    icd10am: string;
}

export interface Diagnosis {
    name: string;
    icd10am: string;
}

export interface DrugOfChoice {
    name: string;
    description: string;
    genericName: string;
}