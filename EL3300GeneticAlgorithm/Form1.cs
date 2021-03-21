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
            List<Chromosome> chroms = new List<Chromosome>();

            private string[] alleleFive = { "10000", "01000", "00100", "00010", "00001" };
            private string[] alleleThree = { "100", "010", "001" };
            private int[] genePositions = { 4, 9, 14, 19, 24, 29, 34, 39, 44, 45, 46, 47, 48, 49 };
            private int totalPopulation, parentIndex;
            private int genBest = 0, overallBest = 0;
            private string bestChrom;
            static int overallBestGrade;
            static string overallBestChrom;            

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

            public void Initialise(int populationSize)
            {
                chroms.Clear();
                Random random = new Random();
                FitFunc grading = new FitFunc();

                totalPopulation = populationSize;
                int fitness;
                string createChrom;

                for (int i = 0; i < populationSize; i++)
                {
                    createChrom = alleleFive[random.Next(5)] + alleleFive[random.Next(5)] + alleleFive[random.Next(5)] + alleleFive[random.Next(5)] +
                        alleleFive[random.Next(5)] + alleleFive[random.Next(5)] + alleleFive[random.Next(5)] + alleleFive[random.Next(5)] +
                        alleleFive[random.Next(5)] + random.Next(0, 2) + random.Next(0, 2) + random.Next(0, 2) + random.Next(0, 2) + random.Next(0, 2)
                        + alleleThree[random.Next(3)];

                    fitness = grading.evalFunc(createChrom);

                    chroms.Add(new Chromosome { Genes = createChrom, Grade = fitness });                                
                }
            }

            public void Selection(int parentPoolSize)
            {
                FitFunc selection = new FitFunc();

                int fitness;
                parentIndex = ((totalPopulation * parentPoolSize) / 100);

                for (int i = 0; i < chroms.Count; i++)
                {
                    fitness = selection.evalFunc(chroms[i].Genes);
                    chroms[i].Grade = fitness;
                }               

                chroms.Sort((a, b) => b.CompareTo(a));
                genBest = chroms[0].Grade;
                chroms.RemoveRange(parentIndex, totalPopulation - parentIndex);              

                if(genBest > overallBest)
                {
                    overallBest = genBest;
                    bestChrom = chroms[0].Genes;
                }
            }

            public void Crossover(bool singlePoint, int numCross)
            {
                Random random = new Random();
                StringBuilder child1 = new StringBuilder();
                StringBuilder child2 = new StringBuilder();

                bool flipflop = true;
                string parent1, parent2, endOfA, endOfB;
                List<int> tempPoints = new List<int> { 5, 10, 15, 20, 25, 30, 35, 40, 45, 46, 47, 48, 49, 50 };
                int[] crossPoints = new int[numCross + 1];
                crossPoints[0] = 0;
                int index;

                if(singlePoint)
                {
                    crossPoints[1] = tempPoints[random.Next(0, tempPoints.Count)];
                }
                else
                {
                    for (int i = 1; i < numCross + 1; i++)
                    {
                        index = random.Next(0, tempPoints.Count);
                        crossPoints[i] = tempPoints[index];

                        tempPoints.RemoveAt(index);
                    }

                    Array.Sort(crossPoints);             
                }             

                while(chroms.Count < totalPopulation)
                {
                    for(int i = 0; i < parentIndex; i += 2)
                    {
                        parent1 = chroms[i].Genes;
                        parent2 = chroms[i + 1].Genes;

                        endOfA = parent1.Substring(crossPoints[numCross]);
                        endOfB = parent2.Substring(crossPoints[numCross]);

                        for (int j = 1; j < numCross + 1; j++)
                        {
                            string a = parent1.Substring(crossPoints[j - 1], crossPoints[j] - crossPoints[j - 1]);

                            if (flipflop)
                            {
                                child1.Append(a);
                            }                                
                            else
                            {
                                child2.Append(a);
                            }

                            string b = parent2.Substring(crossPoints[j - 1], crossPoints[j] - crossPoints[j - 1]);

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

                        if (numCross % 2 == 0)
                        {
                            child1.Append(endOfA);
                            child2.Append(endOfB);                            
                        }

                        else if (numCross % 2 != 0)
                        {
                            child1.Append(endOfB);
                            child2.Append(endOfA);                            
                        }

                        chroms.Add(new Chromosome { Genes = child1.ToString(), Grade = 0 });
                        chroms.Add(new Chromosome { Genes = child2.ToString(), Grade = 0 });

                        child1.Clear();
                        child2.Clear();
                    }
                }
            }

            public void Mutate(bool parents, int chance, int numberOfMutations)
            {
                Random random = new Random();

                int startPoint, endPoint;
                int position, index;
                double mutationChance;
                string tempA, tempB, current, replace, gene;

                if (parents)
                {
                    startPoint = 0;
                    endPoint = parentIndex;
                }
                else
                {
                    startPoint = parentIndex + 1;
                    endPoint = chroms.Count;
                }

                for (int i = startPoint; i < endPoint; i++)
                {
                    List<int> tempPoints = new List<int> { 5, 10, 15, 20, 25, 30, 35, 40, 45, 46, 47, 48, 49, 50 };
                    mutationChance = random.NextDouble() * 100;

                    if (mutationChance <= chance)
                    {
                        for (int j = 0; j < numberOfMutations; j++)
                        {
                            index = random.Next(0, tempPoints.Count);
                            position = tempPoints[index];
                            tempPoints.RemoveAt(index);
                            gene = chroms[i].Genes;

                            if (position < 6)
                            {
                                gene = Chroms[i].Genes;
                                tempB = gene.Substring(position);

                                current = gene.Substring(0, position);
                                replace = alleleFive[random.Next(5)];

                                
                                while (current.Equals(replace))
                                {
                                    replace = alleleFive[random.Next(5)];
                                }

                                chroms[i].Genes = replace + tempB;
                            }
                            else if (position > 6 && position < 45)
                            {
                                gene = Chroms[i].Genes;                 
                                tempA = gene.Substring(0, position);     
                                tempB = gene.Substring(position + 5);
                                current = gene.Substring((position), 5);
                                replace = alleleFive[random.Next(5)];

                                while (current.Equals(replace))
                                {
                                    replace = alleleFive[random.Next(5)];
                                }

                                chroms[i].Genes = tempA + replace + tempB;
                            }
                            else if (position > 45 && position < 50)
                            {
                                gene = chroms[i].Genes;
                                StringBuilder strBuilder = new StringBuilder(gene);

                                if (strBuilder[position - 1] == '1')
                                    strBuilder[position - 1] = '0';
                                else
                                    strBuilder[position - 1] = '1';

                                chroms[i].Genes = strBuilder.ToString();

                            }
                            else if (position >= 49)
                            {
                                gene = chroms[i].Genes; 
                                tempA = gene.Substring(0, (position));
                                current = gene.Substring((position));
                                replace = alleleThree[random.Next(3)];

                                while (current.Equals(replace))
                                {
                                    replace = alleleThree[random.Next(3)];
                                }

                                chroms[i].Genes = tempA + replace;
                            }
                        }
                    }
                }
            }            
        }

        public class Chromosome : IEquatable<Chromosome> , IComparable<Chromosome>
        {
            public string Genes { get; set; }
            public int Grade { get; set; }

            public override string ToString()
            {
                return "Chromosome: " + Genes + "  Grade: " + Grade;
            }

            public int CompareTo(Chromosome compareChrom)
            {
                if (compareChrom == null)
                    return 1;

                else
                    return this.Grade.CompareTo(compareChrom.Grade);
            }
            
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
            Population pop = new Population();
            Random random = new Random();

            int populationSize = (int)numPopSize.Value;
            int mutationChance = (int)numMutationChance.Value;
            int numberOfMutations = (int)numMutations.Value;
            int numberOfCrossovers = (int)numCrossovers.Value;
            int epochs = (int)numEpochs.Value;
            int fitnessGoal = (int)numFitness.Value;
            int poolSize = (int)numPoolSize.Value;
            int randomMutations;
            int bestGrade = 0, epochCount = 0, count = 0;
            string bestChrom, outputParameters, bestParameters;

            tbOutput.Clear();            

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

            if (rbEpochs.Checked)
            {
                for (int i = 0; i < epochs; i++)
                {
                    if (rbCrossRand.Checked)
                    {
                        pop.Crossover(true, 1);
                    }
                    else if(rbNumCross.Checked)
                    {
                        pop.Crossover(false, numberOfCrossovers);
                    }

                    if (cbParents.Checked)
                    {
                        if(rbRandMutation.Checked)
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

                    pop.Selection(poolSize);
                }
            }
            else
            {
                while(bestGrade <= fitnessGoal)
                {
                    if (rbCrossRand.Checked)
                    {
                        pop.Crossover(true, 1);
                    }
                    else if (rbNumCross.Checked)
                    {
                        pop.Crossover(false, numberOfCrossovers);
                    }

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

                    pop.Selection(poolSize);
                    bestGrade = pop.BestGrade;
                    epochCount++;

                    if(epochCount >= 10000)
                    {
                        tbOutput.Text += "Failed to reach target fitness within 10000 epochs." + Environment.NewLine + Environment.NewLine
                            + "Best chromosome after 10000 epochs:" + Environment.NewLine + Environment.NewLine;
                        break;
                    }                    
                }                
            }            

            bestGrade = pop.BestGrade;
            bestChrom = pop.BestChrom;
            outputParameters = getParameters(bestChrom);            

            if(bestGrade > Population.OverallBestGrade)  
            {
                Population.OverallBestGrade = bestGrade;
                Population.OverallBestChrom = bestChrom;

                bestParameters = getParameters(bestChrom);

                tbBest.Text = "Overall Best Chromosome: " + Population.OverallBestChrom + Environment.NewLine + "Grade: " + Population.OverallBestGrade
                + Environment.NewLine + Environment.NewLine + bestParameters;
            }            

            tbOutput.Text += "Best Chromosome: " + bestChrom + Environment.NewLine + "Grade: " + bestGrade + Environment.NewLine + Environment.NewLine;

            tbOutput.Text += "Parameters from best chromosome:" + Environment.NewLine + outputParameters;
        }

        private string getParameters(string chromosome)
        {
            string returnParameters;
            string[] parameters = new string[15];

            for(int i = 0; i < 9; i++)
            {
                parameters[i] = chromosome.Substring(i * 5, 5);
            }

            for(int i = 9; i < 14; i++)
            {
                parameters[i] = chromosome.Substring(45 + (i - 8), 1);
            }

            parameters[14] = chromosome.Substring(50);
            
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

        private void cbParents_CheckedChanged(object sender, EventArgs e)
        {
            cbOffspring.Checked = !cbParents.Checked;
        }

        private void cbOffspring_CheckedChanged(object sender, EventArgs e)
        {
            cbParents.Checked = !cbOffspring.Checked;
        }
    }
}