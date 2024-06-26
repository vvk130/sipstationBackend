// TODO

// public async Task Handle(UpdateTodoItemCommand request, CancellationToken cancellationToken)
// {
//     var entity = await _context.TodoItems
//         .FindAsync(new object[] { request.Id }, cancellationToken);

//     Guard.Against.NotFound(request.Id, entity);

//     entity.Title = request.Title;
//     entity.Done = request.Done; 

//     await _context.SaveChangesAsync(cancellationToken);
// }