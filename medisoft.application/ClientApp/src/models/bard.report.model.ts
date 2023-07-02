export interface Diagnosis {
    name: string;
    // json property
    'icd10-am': string;
    
    
    diagnosisExplaination: string;
    testsNeeds: Test[];
    selected: boolean;
}

export interface Test {
    name: string;
    justification: string;
}

export interface BardReportModel {
    symptoms: Symptom[];
    differentialDiagnosis: Diagnosis[];
    success: boolean;
}

export interface Symptom {
    name: string;
    'icd10-am': string;
}