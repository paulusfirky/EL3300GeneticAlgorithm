using cwklib2020;
using System;
using System.Windows.Forms;
using System.Text;
using System.Collections.Generic;

namespace EL3300GeneticAlgorithm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class Population
        {
            // Instantiate a list of the Chromosomes type named chroms to store the chromosomes of each generation
            List<Chromosome> chroms = new List<Chromosome>();

            // These array of strings will be used to select the genes that have binned parameters
            // alleleFive is used for the first nine genes and alleleThree is used for the 15th gene
            private string[] alleleFive = { "10000", "01000", "00100", "00010", "00001" };
            private string[] alleleThree = { "100", "010", "001" };

            // An array of the positions of the genes (zero-based indeing)
            private int[] genePositions = { 4, 9, 14, 19, 24, 29, 34, 39, 44, 45, 46, 47, 48, 49 };

            // totalPopulation: Used to store the maximum number of chromosomes that will need to be in the list
            // parentIndex: Stores the index location of the last parent in the parent pool
            private int totalPopulation, parentIndex;

            // genBest: Stores the highest grade achieved by the current generation being tested.
            // overallBest: Stores the highest grade achieved through all epochs
            private int genBest = 0, overallBest = 0;

            // bestChrom: Used to store the best chromosome that has been achieved after all epochs
            private string bestChrom;

            // Static variables used to store the best chromosome and the best grade of all runs
            static int overallBestGrade;
            static string overallBestChrom;            

            // Getters and Setters to give access to variables from outside the Population Class
            public List<Chromosome> Chroms
            {
                get { return chroms; }
            }

            public string BestChrom
            {
                get { return bestChrom; }
            }

            public int BestGrade
            {
                get { return overallBest; }
            }

            public static int OverallBestGrade
            {
                get { return overallBestGrade; }
                set { overallBestGrade = value; }
            }

            public static string OverallBestChrom
            {
                get { return overallBestChrom; }
                set { overallBestChrom = value; }
            }

            // Inititalisation function to create the first population for testing
            public void Initialise(int populationSize)
            {
                chroms.Clear();                         // Clear the chroms list to ensure a fresh list
                Random random = new Random();           // Create an instance of Random, used to get random indexes from arrays
                FitFunc grading = new FitFunc();        // Create an instance of the Fitness Function used to grade each chromosome

                int fitness;                            // Stores the fitness grade 
                totalPopulation = populationSize;       // Set the total population to the value passed to the function

                string createChrom;                     // String to store the randomly created chromosomes

                // For loop that will generate chromosomes equal to the total population size
                for (int i = 0; i < populationSize; i++)
                {
                    // Create a string that takes a random allele from the arrays for the first 9 and 15th gene. Generate a 1 or 0 randomly for other genes
                    createChrom = alleleFive[random.Next(5)] + alleleFive[random.Next(5)] + alleleFive[random.Next(5)] + alleleFive[random.Next(5)] +
                        alleleFive[random.Next(5)] + alleleFive[random.Next(5)] + alleleFive[random.Next(5)] + alleleFive[random.Next(5)] +
                        alleleFive[random.Next(5)] + random.Next(0, 2) + random.Next(0, 2) + random.Next(0, 2) + random.Next(0, 2) + random.Next(0, 2)
                        + alleleThree[random.Next(3)];

                    // Evaluate the fitness of the created chromosome and store the result in fitness
                    fitness = grading.evalFunc(createChrom);

                    // Add the newly generated chromosome and its grade to the list of chromosomes
                    chroms.Add(new Chromosome { Genes = createChrom, Grade = fitness });                                
                }
            }

            // Function to grade the fitness of all generated chromosomes and remove the weakest with respect to the parent pool size
            public void Selection(int parentPoolSize)
            {
                FitFunc selection = new FitFunc();

                int fitness;    // Variable to store the calculated fitness of each chromosome

                // Calculate the number of parents by usign the parentPoolSize percentage passed to the function
                parentIndex = ((totalPopulation * parentPoolSize) / 100);

                // For loop that loops as many times as there is chromosomes in the list and calculate the fitness for each and stores the result
                for (int i = 0; i < chroms.Count; i++)
                {
                    fitness = selection.evalFunc(chroms[i].Genes);      // Calculate the fitness of the ith chromosome
                    chroms[i].Grade = fitness;                          // Store the result in the chromosomes Grade variale
                }               

                // Use comparator (Grade) of the Chromosome class to sort chromosomes by grade, modified to be in descending order to get best first
                chroms.Sort((a, b) => b.CompareTo(a));

                //Get the best fitness from the tested population which is now at index 0 after being sorted
                genBest = chroms[0].Grade;

                //Remove the worst part of the generation according to set population pool size        
                chroms.RemoveRange(parentIndex, totalPopulation - parentIndex);              

                // Check to see if the best result of this generation is better than the best of previous generations and if so update the overall best variable
                if(genBest > overallBest)
                {
                    overallBest = genBest;
                    bestChrom = chroms[0].Genes;    // The best grade will be the first in the last after sorting
                }
            }

            // Crossover function that can be set to randomly select a single point to crossover at, or choose multiple random points, depending on the 
            // arguements passed. 
            public void Crossover(bool singlePoint, int numCross)
            {
                Random random = new Random();

                // StringBuilder for the two children to be created so that the string can be appended to
                StringBuilder child1 = new StringBuilder();
                StringBuilder child2 = new StringBuilder();

                bool flipflop = true;       // Bool used to determine whether the string to be added goes to Child 1 or Child 2

                // Parent strings used to store the whole chromosome of each parent, endOfA and endOfB used to store the last part of each parent, to be appended last
                string parent1, parent2, endOfA, endOfB;

                // A list of points that is used to create an array of positions to crossover at. List is used so that positions can be removed easily to avoid
                // the same position being selected twice
                List<int> tempPoints = new List<int> { 5, 10, 15, 20, 25, 30, 35, 40, 45, 46, 47, 48, 49, 50 };

                // Array to store the selected crossover points
                int[] crossPoints = new int[numCross + 1];

                // Set the first crosspoint to be 0, so that the first gene can be selected
                crossPoints[0] = 0;

                // Variable used to select the index to be used to get the position
                int index;

                // If the singlePoint arguement passed is true, select a single random position to crossover at
                if(singlePoint)
                {
                    crossPoints[1] = tempPoints[random.Next(0, tempPoints.Count)];
                }
                // If not using single point, choose a number of positions equal to the numCross arguement passed
                else
                {
                    // For loop that runs as many times as the numCross arguement to generate random positions for crossover
                    for (int i = 1; i < numCross + 1; i++)
                    {
                        index = random.Next(0, tempPoints.Count);   // Select an index randomly between 0 and the total number of points left in the tempPoints list
                        crossPoints[i] = tempPoints[index];         // Save the value from the list to the crossPoints array

                        tempPoints.RemoveAt(index);                 // Remove the crossover point from the list to avoid selecting the same point again
                    }

                    Array.Sort(crossPoints);        // Sort the crossPoints array so that the positions are in ascending numerical order               
                }             

                // A while loop that runs until the number of chromosomes in the list is equal to the totalPopulation variable set up during initialisation
                while(chroms.Count < totalPopulation)
                {
                    // For loop that runs through the parents pool and increases by two each time (for selecting two parents at a time)
                    for(int i = 0; i < parentIndex; i += 2)
                    {
                        // Select two parents from the parent list
                        parent1 = chroms[i].Genes;
                        parent2 = chroms[i + 1].Genes;

                        // Get the end of each parent by creating a substring that starts at the position of the last crossover point to the end of the string
                        endOfA = parent1.Substring(crossPoints[numCross]);
                        endOfB = parent2.Substring(crossPoints[numCross]);

                        // For loop that will run for the selected amount of crossover points
                        for (int j = 1; j < numCross + 1; j++)
                        {
                            // Create a substring from parent 1 that begins at the j - 1 entry of the crossPoints array and has a length equal
                            // to the difference between the current crossover point minus the j - 1 crossover point
                            string a = parent1.Substring(crossPoints[j - 1], crossPoints[j] - crossPoints[j - 1]);

                            // If the flipflop variable is true, append string a to child1, else append it to child2
                            if (flipflop)
                            {
                                child1.Append(a);
                            }                                
                            else
                            {
                                child2.Append(a);
                            }

                            // Create a substring from parent 2, in a similar way as previous string
                            string b = parent2.Substring(crossPoints[j - 1], crossPoints[j] - crossPoints[j - 1]);
                            
                            // If flip flop variable is true, append string b to child 2, else append it to child 1 (opposite of previous if statement
                            // to create a different child
                            // The flipflop variable is now changed so that on the next loop, the strings are appended the opposite way around
                            if(flipflop)
                            {
                                child2.Append(b);
                                flipflop = !flipflop;
                            }
                            else
                            {
                                child1.Append(b);
                                flipflop = !flipflop;
                            }                            
                        }

                        // If there is an even number of crossovers, append the end of parent 1 to child 1 and end of parent 2 to child 2
                        if (numCross % 2 == 0)
                        {
                            child1.Append(endOfA);
                            child2.Append(endOfB);                            
                        }
                        // If there is an odd number of crossovers, append the end of parent 1 to child 2 and end of parent 2 to child 1
                        else if (numCross % 2 != 0)
                        {
                            child1.Append(endOfB);
                            child2.Append(endOfA);                            
                        }

                        // Add the newly generated children to the end of the list, with a default grade of 0
                        chroms.Add(new Chromosome { Genes = child1.ToString(), Grade = 0 });
                        chroms.Add(new Chromosome { Genes = child2.ToString(), Grade = 0 });

                        // Clear the StringBuilders so that new children can be generated
                        child1.Clear();
                        child2.Clear();
                    }
                }
            }

            // Mutation function that can be used to mutate the parents of the current generation. Mutation rate can be set by the chance arguement passed and
            // also the number of mutations
            public void Mutate(bool parents, int chance, int numberOfMutations)
            {
                Random random = new Random();

                int startPoint, endPoint;
                int position, index;        // Variables to keep track of where the mutation should occur
                double mutationChance;      // Used to check whether a mutation should occur on the current parent

                // Strings used to store the genes next to the gene to be replaced, so that the new mutated chromosome can be reconstructed
                string tempA, tempB, current, replace, gene;

                // If the parents boolean is true, set the start point for mutation to the first index of the list
                // and the end point to the parent index to only mutate parents
                if (parents)
                {
                    startPoint = 0;
                    endPoint = parentIndex;
                }
                // If the parents boolean is false, set the start point to the index after the last parent
                // and the end point to the last index of the chroms list
                else
                {
                    startPoint = parentIndex + 1;
                    endPoint = chroms.Count;
                }

                // For loop that runs through all the parents in the list of chromosomes
                for (int i = startPoint; i < endPoint; i++)
                {
                    // A list of the possible points where a mutation could occur
                    List<int> tempPoints = new List<int> { 5, 10, 15, 20, 25, 30, 35, 40, 45, 46, 47, 48, 49, 50 };

                    // mutationChance is a random number between 0.0 and 100.0 which is compared to the chance arguement to determine
                    // whether a mutation will occur
                    mutationChance = random.NextDouble() * 100;

                    // If mutationChance is less than the chance passed to the function a mutation will occur
                    if (mutationChance <= chance)
                    {
                        // Loop as many times as there is mutations to be carried out
                        for (int j = 0; j < numberOfMutations; j++)
                        {
                            index = random.Next(0, tempPoints.Count);   // Generate an index to be used to select the mutation point
                            position = tempPoints[index];               // Get a position from the tempPoints list at the index that was chosen
                            tempPoints.RemoveAt(index);                 // Remove the point from the list to avoid selecting it again
                            gene = chroms[i].Genes;                     // Store the genes of the chromosome at the ith position in the chroms list

                            // If the position is less than six, then the selected gene is the first gene
                            if (position < 6)
                            {
                                gene = Chroms[i].Genes;                 // Ensure that the current genes are stored
                                tempB = gene.Substring(position);       // Create a substring that has all genes after the one to be mutated so they can be appended

                                current = gene.Substring(0, position);  // Get the current value of the gene to be mutated
                                replace = alleleFive[random.Next(5)];   // Select a random gene from 

                                
                                while (current.Equals(replace))
                                {
                                    replace = alleleFive[random.Next(5)];
                                }

                                // Create a new chromosome with the new mutated gene appended with the old genes
                                chroms[i].Genes = replace + tempB;
                            }
                            // If the position is between 6 and 45, the gene has 5 bins so needs to be replaced with a new gene from alleleFive
                            else if (position > 6 && position < 45)
                            {
                                // Ensure that the current genes are stored
                                gene = Chroms[i].Genes;                 

                                // Create a temporary substring that begins at the start of the current chromosome and has a length equal to the
                                // selected random position.
                                // Create another substring that begins 5 characters after the selected position (after the current gene) and 
                                // has all the remaining genes in it
                                tempA = gene.Substring(0, position);     
                                tempB = gene.Substring(position + 5);

                                // Get the value of the current gene at the selected mutation position
                                current = gene.Substring((position), 5);
                                // Get a random new gene from the alleleFive array
                                replace = alleleFive[random.Next(5)];

                                // Check to see if the selected new gene is the same as the current gene and if so, select a different one
                                while (current.Equals(replace))
                                {
                                    replace = alleleFive[random.Next(5)];
                                }

                                // Create a new chromosome from the two temporary strings containing the old genes, and replace the selected gene position
                                // with the new mutated gene and add it to the chroms list
                                chroms[i].Genes = tempA + replace + tempB;
                            }
                            // If the position is between 45 and 50, the gene is only a single character
                            else if (position > 45 && position < 50)
                            {
                                //Ensure that the current genes are stored
                                gene = chroms[i].Genes;

                                // Create a new StringBuilder which will allow for a single character of the string to be changed more easily
                                StringBuilder strBuilder = new StringBuilder(gene);

                                // Check to see what is currently stored at the position of the gene to be mutated
                                // If the current value is 1 change it to 0 and if it is 0 change it to 1
                                if (strBuilder[position - 1] == '1')
                                    strBuilder[position - 1] = '0';
                                else
                                    strBuilder[position - 1] = '1';

                                // Store the mutated chromosome by using the StringBuilder ToString method
                                chroms[i].Genes = strBuilder.ToString();

                            }
                            // If the random position is greater than 49, the gene to be changed is the last one
                            // and the new gene is taken from alleleThree
                            else if (position >= 49)
                            {
                                //Ensure that the current genes are stored 
                                gene = chroms[i].Genes; 

                                // Create a substring that begins at the first gene and goes up to the position of the gene to be mutated
                                tempA = gene.Substring(0, (position));

                                // Store the current gene at the mutation position and selet a random one from the alleleThree array
                                current = gene.Substring((position));
                                replace = alleleThree[random.Next(3)];

                                // Check to see if the selected new gene is the same as the current gene and if so, select a different one
                                while (current.Equals(replace))
                                {
                                    replace = alleleThree[random.Next(3)];
                                }

                                // Store the new genes by appending the mutated gene to the substring created
                                chroms[i].Genes = tempA + replace;
                            }
                        }
                    }
                }
            }            
        }

        // A class that creates the Chromosome type, which is used to store the genes and fitness of a chromosome
        // By storing both in the same type, it is possible to use the comparator in the list to order them
        // by fitness and ensures that the correct grade is attached to the correct chromosome
        // (Adapted from example on MSDN: https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=netframework-4.8 )
        public class Chromosome : IEquatable<Chromosome> , IComparable<Chromosome>
        {
            // Create variables to store the genes and fitness of each chromosome
            public string Genes { get; set; }
            public int Grade { get; set; }

            // This method is implemented so that the chromosome can be converted to a string for printing
            public override string ToString()
            {
                return "Chromosome: " + Genes + "  Grade: " + Grade;
            }

            // Method used so that chromosomes can be compared by using the grade (fitness) using
            // IComparable
            public int CompareTo(Chromosome compareChrom)
            {
                if (compareChrom == null)
                    return 1;

                else
                    return this.Grade.CompareTo(compareChrom.Grade);
            }
            
            // This method sets the hash code to be the Grade of the chromosome
            public override int GetHashCode()
            {
                return Grade;
            }         

            
            public override bool Equals(object obj)
            {
                if (obj == null) return false;
                Chromosome objAsChrom = obj as Chromosome;
                if (objAsChrom == null) return false;
                else return Equals(objAsChrom);
            }           

            
            public bool Equals(Chromosome chrom)
            {
                if (chrom == null) return false;
                return (this.Grade.Equals(chrom.Grade));
            }            
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            // Create a new instane of the Population class
            Population pop = new Population();
            // Create an instance of the Random class in case random numbers are required
            Random random = new Random();

            // Get the values from the NumericUpDown controls on the form and store them as variables
            // that can be used as arguements to pass to the relevant methods of the Population class
            int populationSize = (int)numPopSize.Value;
            int mutationChance = (int)numMutationChance.Value;
            int numberOfMutations = (int)numMutations.Value;
            int numberOfCrossovers = (int)numCrossovers.Value;
            int epochs = (int)numEpochs.Value;
            int fitnessGoal = (int)numFitness.Value;
            int poolSize = (int)numPoolSize.Value;
            int randomMutations;

            // Create a variable to store the bestGrade of each generation and the number of epochs that have elapsed
            // count variables is only used for testing
            int bestGrade = 0, epochCount = 0, count = 0;

            // Create strings to store the best chromosome for printing out the parameters of the overall best chromosome
            string bestChrom, outputParameters, bestParameters;

            // Clear the textbox to ensure no old information is left
            tbOutput.Clear();            

            // Initialise the population, with a size equal to the value of the numPopSize numeric control
            pop.Initialise(populationSize);




            // This commented block of text was used to print a single generation for testing purposes
            // It works similarly to the main implementation, but includes loops to print out the
            // list of chromosomes after each operation

            /*
            tbOutput.Text += "Initial Population:" + Environment.NewLine;

            foreach (var chrom in pop.Chroms)
            {
                count++;
                tbOutput.Text += count.ToString() + ": " + chrom + Environment.NewLine;
            }

            count = 0;
            tbOutput.Text += Environment.NewLine;

            pop.Selection(poolSize);

            tbOutput.Text += "After Selection:" + Environment.NewLine;

            foreach (var chrom in pop.Chroms)
            {
                count++;
                tbOutput.Text += count.ToString() + ": " + chrom + Environment.NewLine;
            }

            count = 0;
            tbOutput.Text += Environment.NewLine;


            if (rbCrossRand.Checked)
            {
                pop.Crossover(false, numberOfCrossovers);
            }
            else if (rbNumCross.Checked)
            {
                pop.Crossover(false, numberOfCrossovers);
            }

            tbOutput.Text += "After Crossover:" + Environment.NewLine;

            foreach (var chrom in pop.Chroms)
            {
                count++;
                tbOutput.Text += count.ToString() + ": " + chrom + Environment.NewLine;
            }

            count = 0;
            tbOutput.Text += Environment.NewLine;

            if (cbParents.Checked)
            {
                if (rbRandMutation.Checked)
                {
                    randomMutations = random.Next(0, 15);
                    pop.Mutate(true, mutationChance, randomMutations);
                }
                else
                {
                    pop.Mutate(true, mutationChance, numberOfMutations);
                }
            }
            else if (cbOffspring.Checked)
            {
                if (rbRandMutation.Checked)
                {
                    randomMutations = random.Next(0, 15);
                    pop.Mutate(false, mutationChance, randomMutations);
                }
                else
                {
                    pop.Mutate(false, mutationChance, numberOfMutations);
                }
            }

            tbOutput.Text += "After Mutation" + Environment.NewLine;

            foreach (var chrom in pop.Chroms)
            {
                count++;
                tbOutput.Text += count.ToString() + ": " + chrom + Environment.NewLine;
            }
            
            count = 0;
            tbOutput.Text += Environment.NewLine;
            */




            
            // If the Number of Epochs radio button is selected, the program will run the number of times set in the numEpochs numeric control
            if (rbEpochs.Checked)
            {
                for (int i = 0; i < epochs; i++)
                {
                    // If the Random Single Crossover radio button is selected, only use one crossover point
                    // and set the single cross boolean to true
                    if (rbCrossRand.Checked)
                    {
                        pop.Crossover(true, 1);
                    }
                    // If the number of crossovers radio button is selected, set single point to false and 
                    // set the number of crossovers to the value of the numCrossovers numeric control
                    else if(rbNumCross.Checked)
                    {
                        pop.Crossover(false, numberOfCrossovers);
                    }

                    // If the Mutate Parents combo box is selected, the Mutate method will called with the parents boolean set to true
                    if (cbParents.Checked)
                    {
                        // If random mutations is selected, generate a random number and use this value to pass as the number of mutations
                        if(rbRandMutation.Checked)
                        {
                            randomMutations = random.Next(0, 15);
                            pop.Mutate(true, mutationChance, randomMutations);
                        }
                        // Else use the value of the numMutations numeric control as the number of mutations and the value of 
                        // numMutationChance numeric control as the value for mutationChance
                        else
                        {
                            pop.Mutate(true, mutationChance, numberOfMutations);
                        }
                    }
                    // If the Mutate Offspring combo box is selected, the Mutate method will be called with the parents boolean set to false
                    else if (cbOffspring.Checked)
                    {
                        // If random mutations is selected, generate a random number and use this value to pass as the number of mutations
                        // Use the value of numMutationChance numeric control as value for mutationChance
                        if (rbRandMutation.Checked)
                        {
                            randomMutations = random.Next(0, 15);
                            pop.Mutate(false, mutationChance, randomMutations);
                        }
                        else
                        {
                            pop.Mutate(false, mutationChance, numberOfMutations);
                        }
                    }                    
                    
                    //Run the selection function on the newly generated chromosomes with the pool size set by numPoolSize numeric control
                    pop.Selection(poolSize);
                }
            }
            // If the target fitness radio button is seleted, the following will run as many epochs as necessary to reach the target fitness.
            // If the target is not reached within 10000 epochs, the loop will finish and display that the fitness was not reached
            // The rest of the loops runs the same as with number of epochs selected
            else
            {
                // Check to see if the bestGrade of the previous generation is greater than or equal to the goal fitness, if not, start a new generation
                while(bestGrade <= fitnessGoal)
                {
                    if (rbCrossRand.Checked)
                    {
                        pop.Crossover(true, 1);
                    }
                    // If the number of crossovers radio button is selected, set single point to false and 
                    // set the number of crossovers to the value of the numCrossovers numeric control
                    else if (rbNumCross.Checked)
                    {
                        pop.Crossover(false, numberOfCrossovers);
                    }

                    // If the Mutate Parents combo box is selected, the Mutate method will called with the parents boolean set to true
                    if (cbParents.Checked)
                    {
                        // If random mutations is selected, generate a random number and use this value to pass as the number of mutations
                        // Use the value of numMutationChance numeric control as value for mutationChance
                        if (rbRandMutation.Checked)
                        {
                            randomMutations = random.Next(0, 15);
                            pop.Mutate(true, mutationChance, randomMutations);
                        }
                        // Else use the value of the numMutations numberic control as the number of mutations and the value of 
                        // numMutationChance numeric control as value for mutationChance
                        else
                        {
                            pop.Mutate(true, mutationChance, numberOfMutations);
                        }
                    }
                    // If the Mutate Offspring combo box is selected, the Mutate method will be called with the parents boolean set to false
                    else if (cbOffspring.Checked)
                    {
                        if (rbRandMutation.Checked)
                        {
                            randomMutations = random.Next(0, 15);
                            pop.Mutate(false, mutationChance, randomMutations);
                        }
                        else
                        {
                            pop.Mutate(false, mutationChance, numberOfMutations);
                        }
                    }

                    pop.Selection(poolSize);

                    bestGrade = pop.BestGrade;
                    // Increase the epochCount variable to keep track of how many generations have been run
                    epochCount++;

                    // If the epochCount variable reaches 10000, stop looping and display a message saying the target fitness has not been reached, 
                    if(epochCount >= 10000)
                    {
                        tbOutput.Text += "Failed to reach target fitness within 10000 epochs." + Environment.NewLine + Environment.NewLine
                            + "Best chromosome after 10000 epochs:" + Environment.NewLine + Environment.NewLine;
                        break;
                    }                    
                }                
            }            

            // Store the values for best grade and best chromosome from the Population class into variables
            bestGrade = pop.BestGrade;
            bestChrom = pop.BestChrom;

            // Get the parameters for each gene (low, medium, high etc)
            outputParameters = getParameters(bestChrom);            

            // If the best grade found during this iteration is better than the overall best grade, change the values of overallBestGrade and OverallBestChrom
            // to the values of the best of this iteration
            if(bestGrade > Population.OverallBestGrade)  
            {
                Population.OverallBestGrade = bestGrade;
                Population.OverallBestChrom = bestChrom;
                // Get the parameters of the new overall best
                bestParameters = getParameters(bestChrom);

                // Update the text of the Overall Best textbox with the values and parameters of the new overall best
                tbBest.Text = "Overall Best Chromosome: " + Population.OverallBestChrom + Environment.NewLine + "Grade: " + Population.OverallBestGrade
                + Environment.NewLine + Environment.NewLine + bestParameters;
            }            

            // Update the Iteration Best textbox with the values obtained for this generation
            tbOutput.Text += "Best Chromosome: " + bestChrom + Environment.NewLine + "Grade: " + bestGrade + Environment.NewLine + Environment.NewLine;

            // Update the Iteration Best textbox with the parameters of this generations best
            tbOutput.Text += "Parameters from best chromosome:" + Environment.NewLine + outputParameters;
        }

        // Funtion that will return a string containing the parameters of the chromosome that is passed to it 
        private string getParameters(string chromosome)
        {
            // String to store the parameters to be returned
            string returnParameters;
            // An array to store the parameters for each gene
            string[] parameters = new string[15];

            // For the first 9 genes, create a substring for each that is 5 characters in length, as these genes
            // are binned parameters with a length of five
            for(int i = 0; i < 9; i++)
            {
                parameters[i] = chromosome.Substring(i * 5, 5);
            }

            // For genes 10-14, create a substring that is one character long as these genes are individual characters
            for(int i = 9; i < 14; i++)
            {
                parameters[i] = chromosome.Substring(45 + (i - 8), 1);
            }

            // Take a substring of the last gene in the chromosome and store it in the last position of the parameters array
            parameters[14] = chromosome.Substring(50);
            
            // For loop that will check each string in parameters and assign it with the relevant parameter
            for(int i = 0; i < parameters.Length; i++)
            {
                if (parameters[i] == "10000")
                    parameters[i] = "Very Low";
                else if (parameters[i] == "01000" || parameters[i] == "100")
                    parameters[i] = "Low";
                else if (parameters[i] == "00100" || parameters[i] == "010")
                    parameters[i] = "Medium";
                else if (parameters[i] == "00010" || parameters[i] == "001")
                    parameters[i] = "High";
                else if (parameters[i] == "00001")
                    parameters[i] = "Very High";
                else if (parameters[i] == "1")
                    parameters[i] = "Fitted";
                else if (parameters[i] == "0")
                    parameters[i] = "Not Fitted";
            }

            // Create a string to be returned that is made up of all the parameters calculated in the previous loop with their associated name
            returnParameters = "External Temperature: " + parameters[0] + Environment.NewLine +
                               "Interal Temperature: " + parameters[1] + Environment.NewLine +
                               "Cylinder Pressure: " + parameters[2] + Environment.NewLine +
                               "Valve Opening Pressure: " + parameters[3] + Environment.NewLine +
                               "Load Torque: " + parameters[4] + Environment.NewLine +
                               "NOx Emissions: " + parameters[5] + Environment.NewLine +
                               "CO Emissions: " + parameters[6] + Environment.NewLine +
                               "HC Emissions: " + parameters[7] + Environment.NewLine +
                               "PM Emissions: " + parameters[8] + Environment.NewLine +
                               "UCLAN Electronic Timing Device: " + parameters[9] + Environment.NewLine +
                               "UCLAN Fuel Flow Device: " + parameters[10] + Environment.NewLine +
                               "UCLAN Emissions Limiter: " + parameters[11] + Environment.NewLine +
                               "UCLAN Battery Management Device: " + parameters[12] + Environment.NewLine +
                               "UCLAN Air Flow Management Device: " + parameters[13] + Environment.NewLine +
                               "Fuel Injection Timings: " + parameters[14];

            return returnParameters;
        }

        // The following two functions ensure that only one of the combo boxes to control mutation can be selected at one time
        private void cbParents_CheckedChanged(object sender, EventArgs e)
        {
            // Set the checked status of the Mutate Offspring combo box to the opposite of the Mutate Parents checked status
            cbOffspring.Checked = !cbParents.Checked;
        }

        private void cbOffspring_CheckedChanged(object sender, EventArgs e)
        {
            // Set the checked status of the Mutate Parents combo box to the opposite of the Mutate Children checked status
            cbParents.Checked = !cbOffspring.Checked;
        }
    }
}