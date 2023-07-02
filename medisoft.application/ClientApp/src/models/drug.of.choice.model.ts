export interface DrugItem {
    genericName: string;
    description: string;
}

export interface DrugOfChoiceModel {
    drugOfChoice: DrugItem[];
    success: boolean;
}