
Project is about (part of) production proccess in a factory for precast(prefabricate).
When there  is a new project(and precast) it  can be added only from Manager(this should be PTO or Chief Engineer).
Project, precast , count of precast, Concrete Class(compressive), ProjectConcreteAmount, ProjectReinforce weight, can be added and edited only by them.
Project or precast could be deleted only if there is no reinforce orderd yet.
Reinforce orders are made only by Reinforce Manager, such as adding editing, deleting  Reinforce Deliverer. If there is orders made to Deliverer, he could not be deleted.
Once made, reinforce order could not be changed. If there is at least four days to delivery day, it could be deleted. Orders are sent to deliverer by email. If something goes wrong and order is not sent,
no record is made in DB, such as for deleting order - if cancelation email is not sent, the record stays in DB.
Precast are produced in three departments. Precast could not be produced, if there is no reinforce.
Production record can be made, edited and deleted, it depends only from reinforce(and count).
Admin can do all of this, and can delete reinforced precast, projects with reinforced precast and orders  with no restriction - in AdminArea.
Ordinary user can see almost everything, but adding, editing, deleting - nothing.
New users are registered only from Admin in AdminArea. Admin can register, delete and update user.

