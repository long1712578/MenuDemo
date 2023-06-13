export interface Menu {
    id: string;
    name: string;
    parentId: string|null;
    menuDtos: Menu[];
}

export interface Menus {
    totalCount: number;
    items: Menu[];
}