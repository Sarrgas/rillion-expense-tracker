using FluentAssertions;

namespace Tests;

public class ExpensesTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void GivenNoExpensesExist_WhenAddingOneExpense_ThenContextContainsOneExpense()
    {
        //Empty Context
        
        //Run AddExpense feature
        
        //Assert context contains one expense
        Assert.Pass();
    }
    
    [Test]
    public void GivenFiveExpensesExist_WhenRetrievingExpensesList_ThenReturnListOfFiveExpenses()
    {
        //Set up context with 5 expenses
        
        //Run Get Expenses List whatevers
        
        //Assert list contains 5 expenses
        Assert.Pass();
    }
    
    [Test]
    public void GivenOneExpenseExist_WhenEditingCategory_ThenExpenseHasNewCategory()
    {
        //Set up context with 1 expense
        
        //Run Edit Expense or whatever
        
        //Assert expense was edited with new value
        Assert.Pass();
    }
    
    [Test]
    public void GivenOneExpenseExist_WhenEditingAmount_ThenExpenseHasNewAmount()
    {
        //Set up context with 1 expense
        
        //Run Edit Expense or whatever
        
        //Assert expense was edited with new value
        Assert.Pass();
    }
    
    [Test]
    public void GivenOneExpenseExist_WhenEditingDescription_ThenError() //TODO Vilket error?
    {
        //Set up context with 1 expense
        
        //Run Edit Expense or whatever
        
        //Expect an error or exception. You did something you are not allowed to do.
        Assert.Pass();
    }
}