namespace C2109I1_Pham_Phuc_Loi.IService;
internal interface ICRUD
{
    void InsertStudent();
    void DeleteStudent(int id);
    void UpdateStudent(int id);
    void PrintStudent();
    void SortById();
    void UpdateAFields(int id);
    void SearchByName(string name);
}
