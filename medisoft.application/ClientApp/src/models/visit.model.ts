import { Doctor } from "./doctor.model";
import { Patient } from "./patient.model";

export interface Visit {
    id: number;
    date: string;
    patient: Patient;
    doctor: Doctor;
}
export var visitsVar: Visit[] = [

    {
        date: '2023-04-06',
        doctor: { id: 1, name: 'Ahmed', age: 30 },
        patient: {
            id: 2, name: 'Fatimah', age: 19, gender: 'female', allergies: [], chronicDiseases: [],
            patientInformation: []
        },
        id: 3
    },
    {
        date: '2023-07-01',
        doctor: { id: 1, name: 'Ahmed', age: 30 },
        patient: {
            id: 3, name: 'Salma', age: 33, gender: 'female', allergies: [], chronicDiseases: [],
            patientInformation: [{ title: 'Past Medical History', description: 'Hypertension' },
            { title: 'Past Surgical History', description: 'Cholecystectomy' },
            { title: 'Medications', description: 'Lisinopril 10 mg by mouth every day' },
            { title: 'Vitals', description: 'Temperature, 97.8 F; heart rate 88; respiratory rate, 22; blood pressure 130/86; body mass index, 28' },
            { title: 'General', description: 'She is well appearing but anxious, a pleasant female lying on a hospital stretcher. She is conversing freely, with respiratory distress causing her to stop mid-sentence.' },

            { title: 'Respiratory', description: 'She has diffuse rales and mild wheezing; tachypneic.' },
            { title: 'Cardiovascular', description: 'She has a regular rate and rhythm with no murmurs, rubs, or gallops.' },
            { title: 'Gastrointestinal', description: 'Bowel sounds X4. No bruits or pulsatile mass.' },

            { title: 'Laboratory Studies', description: 'Initial work-up from the emergency department revealed pancytopenia with a platelet count of 74,000 per mm3; hemoglobin, 8.3 g per and mild transaminase elevation, AST 90 and ALT 112. Blood cultures were drawn and currently negative for bacterial growth or Gram staining.' },
            { title: 'Chest X-ray', description: 'Impression: Mild interstitial pneumonitis' }]
        },
        id: 4
    }
];