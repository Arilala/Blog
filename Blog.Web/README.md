                
                using Blog.Application.Features.Users.Commands.CreateUser;
using Blog.Application.Features.Users.Commands.DeleteUser;
using Blog.Application.Features.Users.Commands.UpdateUser;
using Blog.Application.Features.Users.Queriers.CheckUser;
using Blog.Application.Features.Users.Queriers.GetAllUsers;
using Blog.Application.Features.Users.Queriers.GetUser;
                 try
            {
                for (int i = 1; i < 30; i++)
                {
                    var userInsert = new CreateUserCommand($"monjy-{i}", $"monjy{i}@email.fr", "145264");
                    await _commandMediator.SendAsync(userInsert);


                    await _commandMediator.SendAsync(new DeleteUserCommand(i));
                }


                var userUpdate = new UpdateUserCommand(1, "monjy-1-update", "monjy12@email.com", "145264");
                await _commandMediator.SendAsync(userUpdate);

                var userDelete = new DeleteUserCommand(29);
                await _commandMediator.SendAsync(userDelete);

                var users = await _queryMediator.QueryAsync(new GetAllUsersQuery());
                var user = await _queryMediator.QueryAsync(new GetUserQuery(3));
                var userConnected = await _queryMediator.QueryAsync(new CheckUserQuery("monjy-3", "145264"));

            }
            catch (Exception)
            {

                
            }