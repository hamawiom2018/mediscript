export interface DrugItem {
    genericName: string;
    description: string;
}

export interface DrugOfChoiceModel {
    drugOfChoices: DrugItem[];
    success: boolean;
}